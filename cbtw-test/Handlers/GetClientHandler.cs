using AutoMapper;
using cbtw_test.Queries;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Handlers
{
    public class GetClientHandler : IRequestHandler<GetClientQuery, ClientResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetClientHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ClientResponse> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await _uow.Clients.GetById(request.Id);

            var response = _mapper.Map<ClientResponse>(client);

            return response;
        }
    }
}
