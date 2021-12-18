using BusinessLogic.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.SetClientEnabled
{
    public class SetClientEnabledCommandHandler : IRequestHandler<SetClientEnabledCommandRequest, SetClientEnabledCommandResponse>
    {
        private readonly IClientRepository _clientRepository;

        public SetClientEnabledCommandHandler(
            IClientRepository clientRepository
        )
        {
            _clientRepository = clientRepository;
        }

        public async Task<SetClientEnabledCommandResponse> Handle(SetClientEnabledCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.EnabledValueSet)
                await _clientRepository.Disable(request.Id);
            else
                await _clientRepository.Enable(request.Id);

            return new SetClientEnabledCommandResponse();
        }
    }
}
