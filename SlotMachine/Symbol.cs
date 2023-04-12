namespace SlotMachine
{
    public class Symbol
    {
        public SymbolType SymbolType { get; }

        public decimal Coefficient { get; }

        public Symbol(SymbolType symbolType, decimal coefficient)
        {
            SymbolType = symbolType;
            Coefficient = coefficient;
        }

        public static decimal GetCoefficient(SymbolType symbolType) =>
            symbolType switch
            {
                SymbolType.Apple => 0.4m,
                SymbolType.Banana => 0.6m,
                SymbolType.Pineapple => 0.8m,
                _ => 0m,
            };
    }

    public enum SymbolType
    {
        Apple = 'A',
        Banana = 'B',
        Pineapple = 'P',
        Wildcard = '*'
    }
}
