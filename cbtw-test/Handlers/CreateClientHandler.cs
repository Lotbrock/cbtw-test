using AutoMapper;
using cbtw_test.Command;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Handlers
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, ClientResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateClientHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ClientResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request.Client);

            await _uow.Clients.Add(client);
            await _uow.CompleteAsync();
            return _mapper.Map<ClientResponse>(client);
        }
    }
}
