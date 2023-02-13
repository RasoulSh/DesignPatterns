namespace DesignPatterns.AbstractPatterns.StatePattern
{
    public interface IStateContext
    {
        void TransitionTo(State state);
    }
}
