using Entities.DTOs.Requests;
using MediatR;

namespace cbtw_test.Command
{
    public class UpdateClientCommand : IRequest<bool>
    {
        public UpdateClientResquest Client {  get; }

        public UpdateClientCommand(UpdateClientResquest client)
        {
            Client = client;
        }
    }
}
