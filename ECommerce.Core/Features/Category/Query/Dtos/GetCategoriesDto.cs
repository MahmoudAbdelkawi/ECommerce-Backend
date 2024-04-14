using ECommerce.Core.Response;
using MediatR;


namespace ECommerce.Core.Features.Category.Query.Dtos
{
    public class GetCategoriesDto : IRequest<ApiResponse<List<ECommerce.Domain.Models.Category>>>
    {
    }
}
