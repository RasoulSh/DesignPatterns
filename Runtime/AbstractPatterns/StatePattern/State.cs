namespace DesignPatterns.AbstractPatterns.StatePattern
{
    public abstract class State
    {
        protected IStateContext stateContext;
        public void SetContext(IStateContext stateContext)
        {
            this.stateContext = stateContext;
        }
    }
}
