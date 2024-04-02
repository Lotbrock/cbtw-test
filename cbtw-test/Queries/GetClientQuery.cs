using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Queries
{
    public class GetClientQuery : IRequest<ClientResponse>
    {
        public Guid Id { get; }

        public GetClientQuery(Guid id)
        {
            Id = id;
        }
    }
}
