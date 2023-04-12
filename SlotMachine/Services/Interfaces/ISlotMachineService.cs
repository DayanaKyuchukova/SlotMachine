namespace SlotMachine.Services.Interfaces
{
    public interface ISlotMachineService
    {
        bool IsPlaying { get; set; }
        void Start();
        Tuple<decimal, decimal> Spin(decimal balance, decimal stakeAmount);
        decimal GetWinAmount(decimal stakeAmount);
        decimal CheckRowForWin(int row);
    }
}
