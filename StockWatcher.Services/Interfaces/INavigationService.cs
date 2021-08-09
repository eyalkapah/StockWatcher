namespace StockWatcher.Services.Interfaces
{
    public interface INavigationService
    {
        void SetFrame(object frame);

        void NavigateToLogin();
        void NavigateToCreateAccount();
    }
}
