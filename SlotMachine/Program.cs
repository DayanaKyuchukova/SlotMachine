using Microsoft.Extensions.DependencyInjection;
using SlotMachine.Services.Implementations;
using SlotMachine.Services.Interfaces;
using SlotMachine.States;

namespace SlotMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceCollection = new ServiceCollection()
                .AddScoped<Board>()
                .AddScoped<StartedState>()
                .AddScoped<DepositingState>()
                .AddScoped<SlotGameCreationState>()
                .AddScoped<StakeState>()
                .AddScoped<SpinningState>()
                .AddScoped<InsufficientBalanceState>()
                .AddScoped<ISlotMachineContext, SlotMachineContext>()
                .AddScoped<ISlotMachineService, SlotMachineService>()
                .AddScoped<IBoardService, BoardService>();

            using var serviceProvider = serviceCollection.BuildServiceProvider();

            var slotMachineContext = serviceProvider.GetRequiredService<ISlotMachineContext>();

            slotMachineContext.TransitionTo(SlotMachineStateType.Started);
        }
    }
}