using System;
using System.Collections;
using DesignPatterns.AbstractPatterns.ChainRequestPattern;
using UnityEngine;

namespace DesignPatterns.Tests.TestChainRequest
{
    public class RequestHandler2 : ChainHandler
    {
        protected override IEnumerator Request(object prevResult, Action<ChainResult> callback)
        {
            yield return new WaitForSeconds(5f);
            Debug.Log(string.Format("Five seconds delay. Prev Result: {0}", (prevResult as TestResult).Title));
            callback.Invoke(new ChainResult(){IsSuccessful = true, Message = "Five seconds delay", Output = new TestResult(){Title = "5"}});
        }
    }
}