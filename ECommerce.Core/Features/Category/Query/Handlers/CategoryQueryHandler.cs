using ECommerce.Core.Features.Category.Query.Dtos;
using ECommerce.Core.Response;
using ECommerce.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Core.Features.Category.Query.Handlers
{
    public class CategoryQueryHandler
        : IRequestHandler<GetCategoriesDto, ApiResponse<List<ECommerce.Domain.Models.Category>>>,
        IRequestHandler<GetCategoryByIdDto, ApiResponse<ECommerce.Domain.Models.Category>>

    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<List<Domain.Models.Category>>> Handle(GetCategoriesDto request, CancellationToken cancellationToken)
        {
            var categories = _categoryRepository.GetAsNoTracking();
            return new ApiResponse<List<Domain.Models.Category>>
            {
                Data = await categories.ToListAsync(),
                Message = "Success",
                StatusCode = System.Net.HttpStatusCode.OK,
                Success = true
            };
        }

        public async Task<ApiResponse<Domain.Models.Category>> Handle(GetCategoryByIdDto request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return new ApiResponse<Domain.Models.Category>
                {
                    Data = null,
                    Message = "Category not found",
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Success = false
                };
            }
            return new ApiResponse<Domain.Models.Category>
            {
                Data = category,
                Message = "Success",
                StatusCode = System.Net.HttpStatusCode.OK,
                Success = true
            };
        }
    }
}
