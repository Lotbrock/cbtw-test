using AutoMapper;
using cbtw_test.Command;
using Data.Repositories.Interfaces;
using MediatR;

namespace cbtw_test.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DeleteProductHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = await _uow.Products.Delete(request.Id);
            await _uow.CompleteAsync();

            return response;
        }
    }
}
