namespace SlotMachine.States
{
    public enum SlotMachineStateType
    {
        Started,

        /// <summary>
        /// The transition between the <see cref="Started"/> and <see cref="Deposited"/> state.
        /// Validating the user's input.
        /// </summary>
        Depositing,

        /// <summary>
        /// The state, when the slot game is being chosen, visualized to the user and loaded for preprocessing to the slot machine computer/back-end.
        /// </summary>
        SlotGameCreation,

        /// <summary>
        /// The state, when the user entered amount to bet, but not yet confirmed to be a valid.
        /// </summary>
        Stake,

        /// <summary>
        /// The state, when the stake is confirmed to be valid and the bet processing can be performed.
        /// </summary>
        Spinning,

        /// <summary>
        /// The state, when user's balance is insufficient to continue doing further stakes.
        /// </summary>
        InsufficientBalance,
    }
}
