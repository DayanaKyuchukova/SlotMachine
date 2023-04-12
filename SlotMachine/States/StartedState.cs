namespace SlotMachine.States
{
    public class StartedState : ISlotMachineState
    {
        private readonly ISlotMachineContext _context;

        public StartedState(ISlotMachineContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            // Show some initial fancy animation to take user attention and increase the playing desire.
            _context.TransitionTo(SlotMachineStateType.Depositing);
        }
    }
}
