namespace DesignPatterns.AbstractPatterns.StatePattern
{
    public abstract class StateContext : IStateContext
    {
        private State currentState;
        public void TransitionTo(State state)
        {
            currentState = state;
        }
    }
}
