using AutoMapper;
using cbtw_test.Queries;
using Data.Repositories.Interfaces;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _uow.Products.GetAll();
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }
    }
}
