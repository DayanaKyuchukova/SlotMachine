using SlotMachine.Services;

namespace SlotMachine
{
    public class Board
    {
        public static int BoardRows = 4;
        public static int BoardCols = 3;

        public RandomGenerator generator { get; set; }
        public Symbol[,] symbols;

        public Board()
        {
            generator = new RandomGenerator();
            symbols = new Symbol[BoardRows, BoardCols];
        }
    }
}
