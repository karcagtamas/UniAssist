using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.LocalStorage.StorageOptions;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using UniAssist.Enums;

namespace UniAssist.Services
{
    /// <summary>
    /// Theme Service
    /// </summary>
    public class ThemeService : IThemeService
    {
        /// <summary>
        /// Local Storage.
        /// </summary>
        private readonly ILocalStorageService _localStorage;
        
        /// <summary>
        /// Store Service.
        /// </summary>
        private readonly StoreService _storeService;

        /// <summary>
        /// Initialize Theme Service.
        /// </summary>
        /// <param name="localStorage">Local Storage</param>
        /// <param name="storeService">Store Service</param>
        public ThemeService(ILocalStorageService localStorage, StoreService storeService)
        {
            _localStorage = localStorage;
            _storeService = storeService;
            this.GetThemeFromLocalStorage();    
        }
    
        /// <summary>
        /// Get Theme from local storage.
        /// </summary>
        private async void GetThemeFromLocalStorage()
        {
            this._storeService.SetTheme(await this._localStorage.GetItemAsStringAsync("theme") == "dark" ? ThemeType.Dark : ThemeType.Light);
        }

        /// <summary>
        /// Set theme to local storage by the given Theme's type.
        /// </summary>
        /// <param name="type">Theme type.</param>
        /// <returns>Task</returns>
        public async Task SetTheme(ThemeType type)
        {
            await this._localStorage.SetItemAsync("theme", type == ThemeType.Dark ? "dark" : "light");
            this.GetThemeFromLocalStorage();
        }
    }
}