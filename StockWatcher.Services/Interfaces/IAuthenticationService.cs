using StockWatcher.Models;

namespace StockWatcher.Services.Interfaces
{
    public interface IAuthenticationService
    {
        void Register(Account account);
    }
}
