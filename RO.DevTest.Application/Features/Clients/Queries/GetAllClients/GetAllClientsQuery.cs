using MediatR;
using RO.DevTest.Application.Features.Clients.Queries.Responses;
using System.Collections.Generic;

namespace RO.DevTest.Application.Features.Clients.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<List<ClientDto>>
    {
    }
}
