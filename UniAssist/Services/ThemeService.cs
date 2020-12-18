using System.Threading.Tasks;
using Blazored.LocalStorage;
using UniAssist.Enums;

namespace UniAssist.Services
{
    public class ThemeService
    {
        private readonly ILocalStorageService _localStorage;

        public ThemeType CurrentTheme = ThemeType.Light;

        public ThemeService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            this.GetThemeType();
        }

        private async void GetThemeType()
        {
            this.CurrentTheme = await this._localStorage.GetItemAsStringAsync("theme") == "dark" ? ThemeType.Dark : ThemeType.Light;
        }

        public async Task SetTheme(ThemeType type)
        {
            await this._localStorage.SetItemAsync("theme", type == ThemeType.Dark ? "dark" : "light");
            this.GetThemeType();
        }
    }
}