using Microsoft.Extensions.DependencyInjection;
using SlotMachine.States;

namespace SlotMachine
{
    /// <summary>
    /// State machine class for the slot machine game.
    /// </summary>
    public class SlotMachineContext : ISlotMachineContext
    {
        private readonly IServiceProvider _serviceProvider;

        public SlotMachineContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private ISlotMachineState GetSlotMachineStateByType(SlotMachineStateType stateType)
            => stateType switch
            {
                SlotMachineStateType.Started => _serviceProvider.GetRequiredService<StartedState>(),
                SlotMachineStateType.Depositing => _serviceProvider.GetRequiredService<DepositingState>(),
                SlotMachineStateType.SlotGameCreation => _serviceProvider.GetRequiredService<SlotGameCreationState>(),
                SlotMachineStateType.Stake => _serviceProvider.GetRequiredService<StakeState>(),
                SlotMachineStateType.Spinning => _serviceProvider.GetRequiredService<SpinningState>(),
                SlotMachineStateType.InsufficientBalance => _serviceProvider.GetRequiredService<InsufficientBalanceState>(),
                _ => throw new NotImplementedException($"The provided state type {stateType} is not implemented!"),
            };

        public void TransitionTo(SlotMachineStateType stateType)
        {
            // Log state transitioning...
            GetSlotMachineStateByType(stateType).Handle();
        }
    }
}
