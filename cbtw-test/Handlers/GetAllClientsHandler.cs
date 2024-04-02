using AutoMapper;
using cbtw_test.Queries;
using Data.Repositories.Interfaces;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Handlers
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientResponse>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllClientsHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientResponse>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {

            var clients = await _uow.Clients.GetAll();
            return _mapper.Map<IEnumerable<ClientResponse>>(clients);

        }
    }
}
