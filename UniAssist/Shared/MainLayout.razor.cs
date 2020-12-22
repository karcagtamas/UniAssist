using System;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using UniAssist.Enums;
using UniAssist.Services;

namespace UniAssist.Shared
{
    /// <summary>
    /// MainLayout frame.
    /// </summary>
    public partial class MainLayout : IDisposable
    {
        /// <summary>
        /// Store Service
        /// </summary>
        [Inject]
        private StoreService StoreService { get; set; }

        /// <summary>
        /// Current Theme.
        /// </summary>
        private MatTheme Current { get; set; }

        /// <summary>
        /// Initialize frame.
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            UpdateTheme();
            this.StoreService.OnChange += UpdateTheme;
        }

        /// <summary>
        /// Light theme settings.
        /// </summary>
        readonly MatTheme _lightTheme = new()
        {
            Primary = "#2962ff",
            Secondary = "#880e4f",
            Surface = "#ffffff",
            OnPrimary = "white",
            OnSecondary = "white",
            OnSurface = "black"
        };

        /// <summary>
        /// Dark theme settings.
        /// </summary>
        readonly MatTheme _darkTheme = new()
        {
            Primary = "#2962ff",
            Secondary = "#880e4f",
            Surface = "#242424",
            OnPrimary = "white",
            OnSecondary = "white",
            OnSurface = "white"
        };

        /// <summary>
        /// Get theme settings by Theme type.
        /// </summary>
        /// <returns>Theme settings.</returns>
        private MatTheme GetTheme()
        {
            return this.StoreService.GetTheme() == ThemeType.Dark ? _darkTheme : _lightTheme;
        }

        /// <summary>
        /// Update theme from Store.
        /// </summary>
        private async void UpdateTheme()
        {
            this.Current = this.GetTheme();
            await InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Dispose frame.
        /// </summary>
        public void Dispose()
        {
            this.StoreService.OnChange -= UpdateTheme;
        }
    }
}