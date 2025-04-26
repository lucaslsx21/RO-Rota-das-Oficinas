using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Responses;
using System.Threading.Tasks;
using System.Threading;

namespace RO.DevTest.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, BaseCommandResponse>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
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

            await _clientRepository.DeleteAsync(client);

            return new BaseCommandResponse
            {
                Success = true,
                Message = "Cliente deletado com sucesso"
            };
        }
    }
}
