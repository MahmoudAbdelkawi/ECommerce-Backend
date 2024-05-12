using ECommerce.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Authentication.Command.Dtos
{
    public class ChangePasswordDto : IRequest<ApiResponse<string>>
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Length(6, 20, ErrorMessage = "Password must be between 6 and 20 characters")]
        public string NewPassword { get; set; }
    }
}
