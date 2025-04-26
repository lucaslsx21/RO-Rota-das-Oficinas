using MediatR;
using RO.DevTest.Application.Responses;

namespace RO.DevTest.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<BaseCommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
