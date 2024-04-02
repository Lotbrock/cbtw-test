using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientResponse>>
    {
        public Guid Id { get; set; }
        public double Total { get; set; }

    }
}
