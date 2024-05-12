using ECommerce.Core.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace ECommerce.Core.Features.Authentication.Command.Dtos
{
    public class ForgetPasswordDto
        : IRequest<ApiResponse<string>>
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set;}
    }
}
