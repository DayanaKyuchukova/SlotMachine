namespace SlotMachine.Utils
{
    public interface IRandomGenerator
    {
        static Random Random { get; set; }

        Symbol GenerateRandomSymbol();
    }
}
