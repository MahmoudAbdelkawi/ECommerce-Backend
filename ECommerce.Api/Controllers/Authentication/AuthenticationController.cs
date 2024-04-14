using ECommerce.Api.Controllers.Base;
using ECommerce.Core.Features.Authentication.Command.Dtos;
using ECommerce.Domain.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ECommerce.Api.Controllers.Authentication
{
    [ApiController]
    public class AuthenticationController : BaseController
    {
        [HttpPost(AuthenticationRoutes.Register)]
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            var response = await mediator.Send(signupDto);
            return Result(response);
        }

        [HttpPost(AuthenticationRoutes.Login)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await mediator.Send(loginDto);
            return Result(response);
        }

        [HttpPost(AuthenticationRoutes.ForgotPassword)]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto forgetPasswordDto)
        {
            var response = await mediator.Send(forgetPasswordDto);
            return Result(response);
        }

        [HttpPost(AuthenticationRoutes.ActivationCode)]
        public async Task<IActionResult> ActivationCode(ActivationCodeDto activationCodeDto)
        {
            var response = await mediator.Send(activationCodeDto);
            return Result(response);
        }

        [HttpPatch(AuthenticationRoutes.ChangePassword)]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var response = await mediator.Send(changePasswordDto);
            return Result(response);
        }
    }
}
