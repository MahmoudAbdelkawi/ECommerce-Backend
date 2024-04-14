using ECommerce.Core.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace ECommerce.Core.Features.Authentication.Command.Dtos
{
    public class SignupDto : IRequest<ApiResponse<string>>
    {
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Length(6, 20, ErrorMessage = "Password must be between 6 and 20 characters")]
        public string Password { get; set; }
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}
