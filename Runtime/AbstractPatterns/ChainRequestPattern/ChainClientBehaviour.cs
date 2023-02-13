using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DesignPatterns.AbstractPatterns.ChainRequestPattern
{
    public class ChainClientBehaviour : MonoBehaviour
    {
        private List<ChainHandler> currentChainHandlers;
        private Action<ChainResult> currentChainCallback;

        protected void StartChainRequest(IEnumerable<Type> chain, Action<ChainResult> callback, ChainResult initialResult)
        {
            if (currentChainHandlers != null && currentChainHandlers.Count > 0)
            {
                Debug.LogError("You cannot request while the old request is executing");
                return;
            }
            if (chain == null || chain.Any() == false)
            {
                Debug.LogError("Your chain is empty");
                return;
            }
            currentChainHandlers = new List<ChainHandler>();
            ChainHandler prevHandler = null; 
            foreach (var handlerType in chain)
            {
                var newHandler = gameObject.AddComponent(handlerType) as ChainHandler;
                currentChainHandlers.Add(newHandler);
                if (prevHandler != null)
                {
                    prevHandler.SetNext(newHandler);
                }
                prevHandler = newHandler;
            }
            var promise = new ChainPromise();
            currentChainCallback = callback;
            promise.Callback += OnChainRequestResponse;
            StartCoroutine(currentChainHandlers[0].Handle(promise, initialResult));
        }

        private void OnChainRequestResponse(ChainResult result)
        {
            currentChainCallback.Invoke(result);
            ResetChainClient();
        }

        private void ResetChainClient()
        {
            currentChainCallback = null;
            foreach (var handler in currentChainHandlers)
            {
                Destroy(handler);
            }
            currentChainHandlers.Clear();
        }
    }
}