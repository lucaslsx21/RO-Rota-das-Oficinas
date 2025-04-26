using MediatR;
using RO.DevTest.Application.Responses;
using System;

namespace RO.DevTest.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
