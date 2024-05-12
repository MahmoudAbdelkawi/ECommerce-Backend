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
    public class ActivationCodeDto : IRequest<ApiResponse<string>>
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Length(4, 4, ErrorMessage = "Activation code must be 6 characters")]
        public string ActivationCode { get; set; }
    }
}
