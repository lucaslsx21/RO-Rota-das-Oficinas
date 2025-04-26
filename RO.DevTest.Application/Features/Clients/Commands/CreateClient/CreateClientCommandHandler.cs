using AutoMapper;
using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Responses;
using RO.DevTest.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace RO.DevTest.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, BaseCommandResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };

            await _clientRepository.AddAsync(client);

            return new BaseCommandResponse
            {
                Success = true,
                Message = "Cliente criado com sucesso",
                Id = client.Id
            };
        }
    }
}
