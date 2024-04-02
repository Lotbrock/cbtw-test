using AutoMapper;
using cbtw_test.Command;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using MediatR;

namespace cbtw_test.Handlers
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateClientHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Client>(request.Client);

            await _uow.Clients.Update(entity);
            await _uow.CompleteAsync();
            
            return true;
        }
    }
}
