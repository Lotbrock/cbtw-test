using Entities.DTOs.Requests;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Command
{
    public class CreateClientCommand : IRequest<ClientResponse>
    {
        public CreateClientRequest Client { get; }

        public CreateClientCommand(CreateClientRequest client)
        {
            Client = client;
        }
    }
}
