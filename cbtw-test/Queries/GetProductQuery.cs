using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Queries
{
    public class GetProductQuery : IRequest<ProductResponse>
    {
        public Guid Id { get; }

        public GetProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
