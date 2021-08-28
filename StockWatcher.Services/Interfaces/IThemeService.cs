using StockWatcher.Models.Enums;

namespace StockWatcher.Services.Interfaces
{
    public interface IThemeService
    {
        void SetTheme(Themes theme);
    }
}