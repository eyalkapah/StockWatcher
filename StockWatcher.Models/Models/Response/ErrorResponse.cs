namespace StockWatcher.Models.Models.Response
{
    public class ErrorResponse : IResponse
    {
        public string Message { get; }
        public int StatusCode { get; }

        // C'tor
        //  
        public ErrorResponse(string message, int code)
        {
            Message = message;
            StatusCode = code;
        }

        public bool IsSuccess() => false;
    }
}
