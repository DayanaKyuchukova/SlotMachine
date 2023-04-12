using SlotMachine.Services.Interfaces;

namespace SlotMachine.Services.Implementations
{
    public class SlotMachineService : ISlotMachineService
    {
        private readonly IBoardService _boardService;

        public bool IsPlaying { get; set; }

        public SlotMachineService(IBoardService boardService)
        {
            _boardService = boardService;
            IsPlaying = false;
        }

        public void Start()
        {
            IsPlaying = true;
        }

        public Tuple<decimal, decimal> Spin(decimal balance, decimal stakeAmount)
        {
            balance -= stakeAmount;

            _boardService.FillWithSymbols();

            var winAmount = GetWinAmount(stakeAmount);

            balance += winAmount;

            return new Tuple<decimal, decimal>(winAmount, balance);
        }

        /// <summary>
        /// Calculates the final win amount of the spin
        /// </summary>
        /// <param name="stakeAmount">stakeAmount is the amount you bet on the current spin</param>
        public decimal GetWinAmount(decimal stakeAmount)
        {
            decimal totalWin = 0;

            // Check for wins in each row
            for (int row = 0; row < Board.BoardRows; row++)
            {
                decimal rowWin = CheckRowForWin(row);
                totalWin += rowWin;
            }

            return totalWin * stakeAmount;
        }

        /// <summary>
        /// Checks each line and if it is winning then returns the winning coefficient
        /// </summary>
        public decimal CheckRowForWin(int row)
        {
            var symbols = new List<Symbol>();
            for (int col = 0; col < Board.BoardCols; col++)
            {
                symbols.Add(_boardService.Board.symbols[row, col]);
            }

            var distinctSymbols = symbols.Select(symbol => symbol.SymbolType).Distinct().Count();
            var letter = symbols.First(symbol => symbol.SymbolType != SymbolType.Wildcard).SymbolType;

            if (distinctSymbols == 1)
            {
                return Symbol.GetCoefficient(_boardService.Board.symbols[row, 0].SymbolType) * Board.BoardCols;
            }
            else if (distinctSymbols == 2)
            {
                if (symbols.Count(symbol => symbol.SymbolType == SymbolType.Wildcard) == 1)
                {
                    return Symbol.GetCoefficient(letter) * (Board.BoardCols - 1);
                }
            }

            if (symbols.Count(symbol => symbol.SymbolType == SymbolType.Wildcard) == 2)
            {
                return Symbol.GetCoefficient(letter);
            }

            return 0;
        }
    }
}
