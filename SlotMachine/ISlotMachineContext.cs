using SlotMachine.States;

namespace SlotMachine
{
    public interface ISlotMachineContext
    {
        /// <summary>
        /// With this method we pass from one state to another
        /// </summary>
        /// <param name="stateType"></param>
        void TransitionTo(SlotMachineStateType stateType);
    }
}
