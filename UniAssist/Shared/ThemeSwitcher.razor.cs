using System;
using Microsoft.AspNetCore.Components;
using UniAssist.Enums;
using UniAssist.Services;

namespace UniAssist.Shared
{
    /// <summary>
    /// ThemeSwitcher Component
    /// </summary>
    public partial class ThemeSwitcher : IDisposable
    {
        /// <summary>
        /// Store Service
        /// </summary>
        [Inject]
        private StoreService StoreService { get; set; }

        /// <summary>
        /// Theme Service
        /// </summary>
        [Inject]
        private IThemeService ThemeService { get; set; }

        /// <summary>
        /// Current Theme's type.
        /// </summary>
        private ThemeType ThemeType { get; set; }

        /// <summary>
        /// Setting is dark.
        /// </summary>
        private bool IsDark { get; set; }

        /// <summary>
        /// Initialize Component
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.UpdateTheme();
            this.IsDark = this.ThemeType == ThemeType.Dark;
            this.StoreService.OnChange += UpdateTheme;
        }

        /// <summary>
        /// Change theme by the value.
        /// </summary>
        /// <param name="value">Is dark or not value.</param>
        private async void ThemeChange(bool value)
        {
            await this.ThemeService.SetTheme(value ? ThemeType.Dark : ThemeType.Light);
        }

        /// <summary>
        /// Update theme from Store.
        /// </summary>
        private void UpdateTheme()
        {
            this.ThemeType = this.StoreService.GetTheme();
        }

        /// <summary>
        /// Disposing component
        /// </summary>
        public void Dispose()
        {
            this.StoreService.OnChange -= UpdateTheme;
        }
    }
}