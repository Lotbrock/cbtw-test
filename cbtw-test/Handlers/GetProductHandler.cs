using AutoMapper;
using cbtw_test.Queries;
using Data.Repositories.Interfaces;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetProductHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _uow.Products.GetById(request.Id);
            return _mapper.Map<ProductResponse>(product);
        }
    }
}
