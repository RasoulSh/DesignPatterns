namespace DesignPatterns.AbstractPatterns.ChainRequestPattern
{
    public class ChainPromise
    {
        public event ChainDelegate Callback;
        public delegate void ChainDelegate(ChainResult result);

        public void Invoke(ChainResult result)
        {
            Callback.Invoke(result);
        }
    }
}