using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.LocalStorage.StorageOptions;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using UniAssist.Enums;

namespace UniAssist.Services
{
    public class ThemeService : IThemeService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly StoreService _storeService;

        public ThemeService(ILocalStorageService localStorage, StoreService storeService)
        {
            _localStorage = localStorage;
            _storeService = storeService;
            this.GetThemeFromLocalStorage();    
        }

        private async void GetThemeFromLocalStorage()
        {
            this._storeService.SetTheme(await this._localStorage.GetItemAsStringAsync("theme") == "dark" ? ThemeType.Dark : ThemeType.Light);
        }

        public async Task SetTheme(ThemeType type)
        {
            await this._localStorage.SetItemAsync("theme", type == ThemeType.Dark ? "dark" : "light");
            this.GetThemeFromLocalStorage();
        }
    }
}