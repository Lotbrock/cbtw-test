using AutoMapper;
using cbtw_test.Command;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Handlers
{
    public class CreatePurchaseHandler : IRequestHandler<CreatePurchaseCommand, PurchaseResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreatePurchaseHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<PurchaseResponse> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            Receipt receipt = new Receipt();
            double total = 0;

            var client = await _uow.Clients.GetById(request.PurchaseRequest.ClientId);

            if (client == null)
                return null;

            receipt.Client = client;

            foreach (var item in request.PurchaseRequest.Products)
            {
                var productTemp = await _uow.Products.GetById(item.Id);

                if (productTemp == null)
                    return null;

                ProductReceipt productReceipt = new ProductReceipt();
                productReceipt.Product = productTemp;
                productReceipt.Receipt = receipt;
                productReceipt.Quantity = item.Quantity;

                await _uow.ProductsReceipts.Add(productReceipt);

                total += item.Quantity * productTemp.Value;

            }

            receipt.Total = total;
            await _uow.Receipts.Add(receipt);
            await _uow.CompleteAsync();

            var response = _mapper.Map<PurchaseResponse>(receipt);
            return response;
        }
    }
}
