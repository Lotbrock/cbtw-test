using AutoMapper;
using cbtw_test.Command;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using MediatR;

namespace cbtw_test.Handlers
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DeleteClientHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var response = await _uow.Clients.Delete(request.Id);
            await _uow.CompleteAsync();
            
            return true;
        }
    }
}
