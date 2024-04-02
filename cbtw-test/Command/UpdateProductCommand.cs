using Entities.DTOs.Requests;
using MediatR;

namespace cbtw_test.Command
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public UpdateProductRequest Product { get; }

        public UpdateProductCommand(UpdateProductRequest product)
        {
            Product = product;
        }
    }
}
  