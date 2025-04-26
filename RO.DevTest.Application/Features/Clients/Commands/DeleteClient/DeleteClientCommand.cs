using MediatR;
using RO.DevTest.Application.Responses;
using System;

namespace RO.DevTest.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
