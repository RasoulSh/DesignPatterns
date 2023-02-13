using System.Collections;

namespace DesignPatterns.AbstractPatterns.ChainRequestPattern
{
    public interface IChainHandler
    {
        IChainHandler SetNext(IChainHandler nextHandler);
        IEnumerator Handle(ChainPromise promise, ChainResult result);
    }
}