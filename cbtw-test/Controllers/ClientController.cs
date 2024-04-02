using AutoMapper;
using cbtw_test.Command;
using cbtw_test.Queries;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Entities.DTOs.Requests;
using Entities.DTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cbtw_test.Controllers
{
    public class ClientController : BaseController
    {
        public ClientController(IUnitOfWork uow, IMapper mapper, IMediator mediator) : base(uow, mapper, mediator)
        {
        }

        [HttpGet]
        [Route("{clientId:guid}")]
        public async Task<ActionResult> GetById(Guid clientId)
        {
            
            var client = await _mediator.Send(new GetClientQuery(clientId));

            if (client == null)
                return NotFound();


            return Ok(client);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var clients = await _mediator.Send(new GetAllClientsQuery());

            if (clients == null || !clients.Any())
                return NotFound();

            return Ok(clients);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add([FromBody]CreateClientRequest req)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var client = await _mediator.Send(new CreateClientCommand(req));
           
            return CreatedAtAction(nameof(GetById), new {clientId = client.Id }, client);

        }

        [HttpDelete]
        [Route("{clientId:guid}")]
        public async Task<ActionResult> Delete(Guid clientId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _mediator.Send(new DeleteClientCommand(clientId));

            return response ? Ok() : NotFound();

        }

        [HttpPut("")]
        public async Task<ActionResult> Update([FromBody] UpdateClientResquest req)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new UpdateClientCommand(req));

            return result ? Ok() : BadRequest();
        }


    }
}
