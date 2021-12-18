using MediatR;

namespace BusinessLogic.Actions.SetClientEnabled
{
    public class SetClientEnabledCommandRequest : IRequest<SetClientEnabledCommandResponse>
    {
        public int Id { get; set; }
        public bool EnabledValueSet { get; set; }

        public SetClientEnabledCommandRequest(int id, bool enabledValueSet)
        {
            Id = id;
            EnabledValueSet = enabledValueSet;
        }
    }
}
