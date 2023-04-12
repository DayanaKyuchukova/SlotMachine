using SlotMachine.Utils;

namespace SlotMachine.Services
{
    public class RandomGenerator : IRandomGenerator
    {
        public static Random Random { get; set; }

        public RandomGenerator()
        {
            Random = new Random();
        }

        public Symbol GenerateRandomSymbol()
        {
            var randomNumber = Random.Next(1, 101);

            return randomNumber switch
            {
                var n when n <= 5 => new Symbol(SymbolType.Wildcard, 0),
                var n when n <= 50 => new Symbol(SymbolType.Apple, 0.4m),
                var n when n <= 85 => new Symbol(SymbolType.Banana, 0.6m),
                _ => new Symbol(SymbolType.Pineapple, 0.8m)
            };
        }
    }
}
