using MediatR;
using RO.DevTest.Application.Features.Clients.Queries.Responses;
using System;

namespace RO.DevTest.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<ClientDto>
    {
        public Guid Id { get; set; }

        public GetClientByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
