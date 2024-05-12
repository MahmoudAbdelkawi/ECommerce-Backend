using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Task<string> Signup (User user, string password);
        public Task<string> Login (string email, string password);
        public Task ForgetPassword (string email);
        public Task<bool> ActivationCode (string email, string code);
        public Task ChangePassword (string email, string password);
        public Task<User> FindByEmail(string email);
        public Task<User> FindByUserName(string userName);
    }
}
