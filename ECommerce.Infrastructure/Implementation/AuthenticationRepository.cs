using ECommerce.Domain.Enums;
using ECommerce.Domain.Helpers;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Infrastructure.Implementation
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SendMail _sendMail;
        private readonly JWT _jwt;

        public AuthenticationRepository(UserManager<User> userManager, IOptions<JWT> jwt, ApplicationDbContext context, SendMail sendMail)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _context = context;
            _sendMail = sendMail;
        }

        public async Task<bool> ActivationCode(string email, string code)
        {

            // find by email and join with the user verification code
            var user = await _context.Users.Where(u => u.Email == email)
                .Include(u => u.UserVerificationCodes)
                .SingleOrDefaultAsync();

            if (user is null)
            {
                return false;
            }

            // compare the code and the email and check on the expiration date
            var verificationCode = user.UserVerificationCodes.OrderByDescending(v => v.CreatedAt).FirstOrDefault();
            if (verificationCode.Code != code || verificationCode.ExpirationDate < DateTime.Now)
            {
                return false;
            }

            // if the code is correct and update CanChangePassword to true and CanChangePasswordAvailability to DateTime.Now.AddMinutes(3)
            verificationCode.CanChangePassword = true;
            verificationCode.CanChangePasswordAvailability = DateTime.Now.AddMinutes(3);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task ChangePassword(string email, string password)
        {
            var user = await _context.Users.Where(u => u.Email == email)
                .Include(u => u.UserVerificationCodes)
                .SingleOrDefaultAsync();

            var verificationCode = user.UserVerificationCodes.OrderByDescending(v => v.CreatedAt).FirstOrDefault();

            if (verificationCode.CanChangePassword && verificationCode.CanChangePasswordAvailability > DateTime.Now)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password); 
                verificationCode.CanChangePassword = false;
                verificationCode.CanChangePasswordAvailability = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> FindByUserName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            // Generate a random code
            var code = GenerateRandomCode();

            // save the code in the database
            await _context.UserVerificationCodes.AddAsync(new UserVerificationCodes
            {
                Code = code,
                UserId = user.Id,
            });

            // send the code to the user
            var to = new List<MailboxAddress>();
            to.Add(new MailboxAddress("email", email));

            var subject = "Forget Password";

            var body = $"Your code is {code}";

            _sendMail.SendEmail(to , subject , body);

            await _context.SaveChangesAsync();
        }

        private string GenerateRandomCode()
        {
            var random = new Random();
            var code = random.Next(1000, 9999).ToString();

            return code;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return null;
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordValid)
            {
                return null;
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        public async Task<string> Signup(User user, string password)
        {
            await _userManager.CreateAsync(user, password);

            await _userManager.AddToRoleAsync(user, Roles.User.ToString());

            var jwtSecurityToken = await CreateJwtToken(user);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.NameIdentifier , user.Id),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role , roles.FirstOrDefault()),
                new Claim(ClaimTypes.Email , user.Email)
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.ExpiryInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
