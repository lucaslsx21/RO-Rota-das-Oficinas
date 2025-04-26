using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Responses;
using System.Threading.Tasks;
using System.Threading;

namespace RO.DevTest.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, BaseCommandResponse>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<BaseCommandResponse> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            if (client == null)
            {
                return new BaseCommandResponse
                {
                    Success = false,
                    Message = "Cliente não encontrado"
                };
            }

            client.Name = request.Name;
            client.Email = request.Email;
            client.PhoneNumber = request.PhoneNumber;
            client.Address = request.Address;

            await _clientRepository.UpdateAsync(client);

            return new BaseCommandResponse
            {
                Success = true,
                Message = "Cliente atualizado com sucesso"
            };
        }
    }
}
