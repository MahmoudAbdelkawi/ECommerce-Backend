using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Implementation
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public UserProfileRepository(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<User> GetUserAsync()
        {
            var userId = GetUserId();
            if (userId == null)
            {
                return null;
            }
            return await _userManager.FindByIdAsync(userId);
        }

        public string GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
    }
}
