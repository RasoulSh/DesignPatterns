using System;
using System.Collections;
using DesignPatterns.AbstractPatterns.ChainRequestPattern;
using UnityEngine;

namespace DesignPatterns.Tests.TestChainRequest
{
    public class RequestHandler3 : ChainHandler
    {
        protected override IEnumerator Request(object prevResult, Action<ChainResult> callback)
        {
            yield return new WaitForSeconds(8f);
            Debug.Log(string.Format("Eight seconds delay. Prev Result: {0}", (prevResult as TestResult).Title));
            callback.Invoke(new ChainResult(){IsSuccessful = true, Message = "Eight seconds delay", Output = new TestResult(){Title = "8"}});
        }
    }
}