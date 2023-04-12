using SlotMachine.Services.Interfaces;

namespace SlotMachine.States
{
    public class SlotGameCreationState : ISlotMachineState
    {
        private readonly ISlotMachineContext _context;
        private readonly ISlotMachineService _slotMachineService;

        public SlotGameCreationState(ISlotMachineContext context, ISlotMachineService slotMachineService)
        {
            _context = context;
            _slotMachineService = slotMachineService;
        }

        public void Handle()
        {
            _slotMachineService.Start();

            _context.TransitionTo(SlotMachineStateType.Stake);
        }
    }
}
