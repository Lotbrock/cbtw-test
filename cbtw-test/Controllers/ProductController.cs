using AutoMapper;
using cbtw_test.Command;
using cbtw_test.Queries;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Entities.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cbtw_test.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork uow, IMapper mapper, IMediator mediator) : base(uow, mapper, mediator)
        {
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetProductQuery(id));

            if (product == null)
                return NotFound();


            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            if (products == null || !products.Any())
                return NotFound();

            return Ok(products);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add([FromBody] CreateProductRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = await _mediator.Send(new CreateProductCommand(req));

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _mediator.Send(new DeleteProductCommand(id));
            return response ? Ok() : NotFound();

        }

        [HttpPut("")]
        public async Task<ActionResult> Update([FromBody] UpdateProductRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var entity = await _mediator.Send(new UpdateProductCommand(req));


            return entity ? Ok() : NotFound();
        }


    }
}
