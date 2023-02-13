using DesignPatterns.AbstractPatterns.ChainRequestPattern;
using UnityEngine;

namespace DesignPatterns.Tests.TestChainRequest
{
    public class TestChainClient : ChainClientBehaviour
    {
        private void Start()
        {
            StartChainRequest(new []{typeof(RequestHandler1), typeof(RequestHandler2), typeof(RequestHandler3)},OnRequestResponse, null);
        }
        
        private void OnRequestResponse(ChainResult result)
        {
            Debug.Log(string.Format("Success: {0}, Message: {1}, data: {2}", result.IsSuccessful, result.Message, (result.Output as TestResult).Title));
        }
    }
}