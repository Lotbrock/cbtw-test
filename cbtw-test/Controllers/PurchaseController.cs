using AutoMapper;
using cbtw_test.Command;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Entities.DTOs.Requests;
using Entities.DTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cbtw_test.Controllers
{
    public class PurchaseController : BaseController
    {
        public PurchaseController(IUnitOfWork uow, IMapper mapper, IMediator mediator) : base(uow, mapper, mediator)
        {
        }

        [HttpPost("")]
        public async Task<ActionResult> RegisterPurchase([FromBody] PurchaseRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest();

           var response = await _mediator.Send(new CreatePurchaseCommand(req));

            return response == null ? BadRequest() : Ok(response);

        }

    }
}


