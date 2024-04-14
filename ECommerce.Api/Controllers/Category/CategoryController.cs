using ECommerce.Api.Controllers.Base;
using ECommerce.Core.Features.Category.Query.Dtos;
using ECommerce.Domain.Routes;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers.Category
{
    public class CategoryController : BaseController
    {
        [HttpGet(CategoryRoutes.GetCategories)]
        public async Task<IActionResult> GetCategories()
        {
            var response = await mediator.Send(new GetCategoriesDto());
            return Result(response);
        }

        [HttpGet(CategoryRoutes.GetCategoryById)]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var response = await mediator.Send(new GetCategoryByIdDto { Id = id });
            return Result(response);
        }
    }
}
