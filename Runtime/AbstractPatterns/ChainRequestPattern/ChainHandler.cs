using System;
using System.Collections;
using UnityEngine;

namespace DesignPatterns.AbstractPatterns.ChainRequestPattern
{
    public abstract class ChainHandler : MonoBehaviour, IChainHandler
    {
        private IChainHandler _nextHandler;
        public IChainHandler SetNext(IChainHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }

        protected abstract IEnumerator Request(object prevResult, Action<ChainResult> callback);

        public IEnumerator Handle(ChainPromise promise, ChainResult result)
        {
            if (result is { IsSuccessful: false })
            {
                promise.Invoke(result);
                yield break;
            }
            yield return StartCoroutine(Request(result?.Output, requestResult =>
            {
                if (_nextHandler != null)
                {
                    StartCoroutine(_nextHandler.Handle(promise, requestResult));   
                }
                else
                {
                    promise.Invoke(requestResult != null ? requestResult : new ChainResult()
                    {
                        IsSuccessful = false, Message = "Your chain has problems"
                    });
                }
            }));
        }
    }
}