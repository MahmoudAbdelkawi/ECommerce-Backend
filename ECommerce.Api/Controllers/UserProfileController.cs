using ECommerce.Api.Controllers.Base;
using ECommerce.Core.Features.UserProfile.Query.Dtos;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Authorize(Roles = nameof(Roles.User) + "," + nameof(Roles.Admin))]
    [ApiController]
    public class UserProfileController : BaseController
    {
        [HttpGet(UserProfileRoutes.GetMe)]
        public async Task<IActionResult> GetMe()
        {
            var response = await mediator.Send(new GetMeDto());
            return Result(response);
        }
    }
}
