namespace SlotMachine.States
{
    public class StakeState : ISlotMachineState
    {
        private readonly ISlotMachineContext _context;

        public StakeState(ISlotMachineContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            Console.WriteLine("Please enter the amount you want to stake: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal money) && money > 0)
            {
                if (Database.Balance < money)
                {
                    Console.WriteLine("Not enough balance to stake this amount.");
                    _context.TransitionTo(SlotMachineStateType.Stake);
                }

                Database.StakedMoney = money;

                _context.TransitionTo(SlotMachineStateType.Spinning);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");

                _context.TransitionTo(SlotMachineStateType.Stake);
            }
        }
    }
}
