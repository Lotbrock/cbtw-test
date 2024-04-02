using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductResponse>>
    {
    }
}
