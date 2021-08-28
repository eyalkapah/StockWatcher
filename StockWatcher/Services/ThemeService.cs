using StockWatcher.Models.Enums;
using StockWatcher.Services.Interfaces;
using System;
using System.Linq;
using System.Windows;

namespace StockWatcher.Services
{
    public class ThemeService : IThemeService
    {
        public const string LightThemePath = "Resources/Themes/LightTheme.xaml";
        public const string DarkThemePath = "Resources/Themes/DarkTheme.xaml";

        public void SetTheme(Themes theme)
        {
            string currentThemePath;
            string newThemePath;

            switch (theme)
            {
                case Themes.Light:
                    currentThemePath = DarkThemePath;
                    newThemePath = LightThemePath;
                    break;
                case Themes.Dark:
                    currentThemePath = LightThemePath;
                    newThemePath = DarkThemePath;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(theme), theme, null);
            }

            var resource = Application.Current.Resources.MergedDictionaries.FirstOrDefault(currentResource =>
                currentResource.Source.ToString().Equals(currentThemePath));

            if (resource == default(ResourceDictionary)) 
                return;
            
            Application.Current.Resources.MergedDictionaries.Remove(resource);

            var dict = new ResourceDictionary
            {
                Source = new Uri(newThemePath, UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Add(dict);

        }
    }
}
