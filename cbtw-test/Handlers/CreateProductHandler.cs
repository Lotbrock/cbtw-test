using AutoMapper;
using cbtw_test.Command;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateProductHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.Product);

            await _uow.Products.Add(product);
            await _uow.CompleteAsync();

            return _mapper.Map<ProductResponse>(product);
        }
    }
}
