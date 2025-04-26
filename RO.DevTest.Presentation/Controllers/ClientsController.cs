using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Clients.Commands.CreateClient;
using RO.DevTest.Application.Features.Clients.Commands.DeleteClient;
using RO.DevTest.Application.Features.Clients.Commands.UpdateClient;
using RO.DevTest.Application.Features.Clients.Queries.GetAllClients;
using RO.DevTest.Application.Features.Clients.Queries.GetClientById;
using System.Threading.Tasks;
using System;

namespace RO.DevTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateClientCommand command)
        {
            if (id != command.Id)
                return BadRequest("IDs diferentes");

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteClientCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetClientByIdQuery(id);
            var client = await _mediator.Send(query);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllClientsQuery();
            var clients = await _mediator.Send(query);
            return Ok(clients);
        }
    }
}
