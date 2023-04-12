using SlotMachine.Services.Interfaces;

namespace SlotMachine.Services.Implementations
{
    public class BoardService : IBoardService
    {
        public Board Board { get; set; }

        public BoardService(Board board)
        {
            Board = board;
        }

        /// <summary>
        /// Fill the board with symbols
        /// </summary>
        public void FillWithSymbols()
        {
            for (var i = 0; i < Board.BoardRows; i++)
            {
                for (var j = 0; j < Board.BoardCols; j++)
                {
                    var symbol = Board.generator.GenerateRandomSymbol();
                    Board.symbols[i, j] = symbol;
                }
            }
        }

        /// <summary>
        /// Print the board with symbols
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Board.BoardRows; i++)
            {
                for (int j = 0; j < Board.BoardCols; j++)
                {
                    Console.Write(((char)Board.symbols[i, j].SymbolType).ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
