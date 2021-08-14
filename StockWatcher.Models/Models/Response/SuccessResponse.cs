namespace StockWatcher.Models.Models.Response
{
    public class SuccessResponse : IResponse
    {
        public string Message { get; }
        public int StatusCode { get; }

        // C'tor
        //
        public SuccessResponse()
        {
        }

        // C'tor
        //
        public SuccessResponse(string message, int code)
        {
            Message = message;
            StatusCode = code;
        }

        public bool IsSuccess()
        {
            return true;
        }
    }
}