using Entities.DTOs.Requests;
using Entities.DTOs.Responses;
using MediatR;

namespace cbtw_test.Command
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public CreateProductRequest Product { get; }

        public CreateProductCommand(CreateProductRequest product)
        {
            Product = product;
        }
    }
}
