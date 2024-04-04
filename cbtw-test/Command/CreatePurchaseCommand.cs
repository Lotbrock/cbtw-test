using Entities.DTOs.Requests;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Command
{
    public class CreatePurchaseCommand : IRequest<PurchaseResponse>
    {
        public PurchaseRequest PurchaseRequest { get;}

        public CreatePurchaseCommand(PurchaseRequest purchaseRequest)
        {
            PurchaseRequest = purchaseRequest;
        }
    }
}
