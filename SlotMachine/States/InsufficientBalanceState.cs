namespace SlotMachine.States
{
    public class InsufficientBalanceState : ISlotMachineState
    {
        private readonly ISlotMachineContext _context;

        public InsufficientBalanceState(ISlotMachineContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            //TODO: After the end of the game to ask the client if he wants to start a new game
            Console.WriteLine("Game over!");
            Environment.Exit(0);
        }
    }
}
