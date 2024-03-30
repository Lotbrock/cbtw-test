using AutoMapper;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Entities.DTOs.Requests;
using Entities.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace cbtw_test.Controllers
{
    public class ClientController : BaseController
    {
        public ClientController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        [HttpGet]
        [Route("{clientId:guid}")]
        public async Task<ActionResult> GetById(Guid clientId)
        {
            var client = await _uow.Clients.GetById(clientId);

            if (client == null)
                return NotFound();


            return Ok(client);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var clients = await _uow.Clients.GetAll();

            if (clients == null || !clients.Any())
                return NotFound();

            return Ok(clients);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add([FromBody]CreateClientRequest req)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var client = _mapper.Map<Client>(req);

            await _uow.Clients.Add(client);
            await _uow.CompleteAsync();
           
            return CreatedAtAction(nameof(GetById), new {clientId = client.Id }, client);

        }

        [HttpDelete]
        [Route("{clientId:guid}")]
        public async Task<ActionResult> Delete(Guid clientId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _uow.Clients.Delete(clientId);
            await _uow.CompleteAsync();

            return response ? Ok() : NotFound();

        }

        [HttpPut("")]
        public async Task<ActionResult> Update([FromBody] UpdateClientResquest req)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var entity = _mapper.Map<Client>(req);

           await _uow.Clients.Update(entity);
            await _uow.CompleteAsync();


            return NoContent();
        }


    }
}
