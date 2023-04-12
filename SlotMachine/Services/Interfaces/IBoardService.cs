namespace SlotMachine.Services.Interfaces
{
    public interface IBoardService
    {
        Board Board { get; set; }

        void FillWithSymbols();

        void Print();
    }
}
