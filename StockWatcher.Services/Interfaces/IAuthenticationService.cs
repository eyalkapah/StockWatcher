using System.Threading.Tasks;
using StockWatcher.Models;
using StockWatcher.Models.Models;
using StockWatcher.Models.Models.Response;

namespace StockWatcher.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IResponse> RegisterAsync(Account account);
        Task<bool> AuthenticateAsync(string username, string password);
        AuthenticatedUser GetAuthenticatedUser();
        void LogOut();
    }
}
