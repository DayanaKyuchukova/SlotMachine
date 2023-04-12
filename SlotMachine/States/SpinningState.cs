using SlotMachine.Services.Interfaces;

namespace SlotMachine.States
{
    public class SpinningState : ISlotMachineState
    {
        private readonly ISlotMachineContext _context;
        private readonly ISlotMachineService _slotMachineService;
        private readonly IBoardService _boardService;

        public SpinningState(ISlotMachineContext context, ISlotMachineService slotMachineService, IBoardService boardService)
        {
            _context = context;
            _slotMachineService = slotMachineService;
            _boardService = boardService;
        }

        public void Handle()
        {
            var spinResult = _slotMachineService.Spin(Database.Balance, Database.StakedMoney);

            Console.WriteLine();
            Console.WriteLine("Spin result:");
            _boardService.Print();
            Console.WriteLine();

            if (spinResult.Item1 > 0)
            {
                Console.WriteLine($"Congratulations! You won {spinResult.Item1}.");
            }
            else
            {
                Console.WriteLine("Sorry, you didn't win this time.");
            }

            Database.Balance = spinResult.Item2;
            Console.WriteLine($"Current balance is: {Database.Balance}");
            Console.WriteLine();

            if (Database.Balance > 0)
            {
                _context.TransitionTo(SlotMachineStateType.Stake);
            }
            else
            {
                _context.TransitionTo(SlotMachineStateType.InsufficientBalance);
            }
        }
    }
}
