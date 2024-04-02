using AutoMapper;
using cbtw_test.Command;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using MediatR;

namespace cbtw_test.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request.Product);
            var response = await _uow.Products.Update(entity);
            await _uow.CompleteAsync();

            return response;
        }
    }
}
