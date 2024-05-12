using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Routes
{
    public static class AuthenticationRoutes
    {
        public const string Register = "api/auth/register";
        public const string Login = "api/auth/login";
        public const string VerifyEmail = "api/auth/verify-email";
        public const string ForgotPassword = "api/auth/forgot-password";
        public const string ActivationCode = "api/auth/activation-code";
        public const string ChangePassword = "api/auth/change-password";
    }
}
