using AutoMapper;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Entities.DTOs.Requests;
using Entities.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace cbtw_test.Controllers
{
    public class PurchaseController : BaseController
    {
        public PurchaseController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        [HttpPost("")]
        public async Task<ActionResult> RegisterPurchase([FromBody] PurchaseRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Receipt receipt = new Receipt();
            double total = 0;

            var client = await _uow.Clients.GetById(req.ClientId);

            if (client == null)
                return BadRequest();

            receipt.Client = client;

            foreach (var item in req.Products)
            {
                var productTemp = await _uow.Products.GetById(item.Id);

                if (productTemp == null)
                    return BadRequest();

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

            return Ok(response);

        }

    }
}


