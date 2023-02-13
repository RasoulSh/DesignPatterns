namespace DesignPatterns.AbstractPatterns.ChainRequestPattern
{
    public class ChainResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public object Output { get; set; }
    }
}