namespace SlotMachine.States
{
    public class DepositingState : ISlotMachineState
    {
        private readonly ISlotMachineContext _context;

        public DepositingState(ISlotMachineContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            Console.WriteLine("Please enter your initial deposit money: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal money) && money > 0)
            {
                // TODO: Store the money that the user just deposited successfully.
                Database.Balance = money;

                _context.TransitionTo(SlotMachineStateType.SlotGameCreation);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");

                _context.TransitionTo(SlotMachineStateType.Depositing);
            }
        }
    }
}
