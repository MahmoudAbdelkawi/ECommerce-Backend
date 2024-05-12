using ECommerce.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Category.Query.Dtos
{
    public class GetCategoryByIdDto : IRequest<ApiResponse<ECommerce.Domain.Models.Category>>
    {
        public Guid Id { get; set; }
    }
}
