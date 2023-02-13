using System;
using System.Collections;
using DesignPatterns.AbstractPatterns.ChainRequestPattern;
using UnityEngine;

namespace DesignPatterns.Tests.TestChainRequest
{
    public class RequestHandler1 : ChainHandler
    {
        protected override IEnumerator Request(object prevResult, Action<ChainResult> callback)
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("Three seconds delay");
            callback.Invoke(new ChainResult(){IsSuccessful = true, Message = "Three seconds delay", Output = new TestResult(){Title = "3"}});
        }
    }
}