namespace StockWatcher.Models.Models.Response
{
    public interface IResponse
    {
        string Message { get; }
        int StatusCode { get; }

        bool IsSuccess();
    }
}
