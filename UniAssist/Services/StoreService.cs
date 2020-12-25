using System;
using UniAssist.Enums;
using UniAssist.Models;

namespace UniAssist.Services
{
    /// <summary>
    /// Store Service
    /// </summary>
    public class StoreService
    {
        /// <summary>
        /// Store
        /// </summary>
        private Store Store { get; set; }
        
        /// <summary>
        /// Store change event.
        /// </summary>
        public event Action OnChange;

        /// <summary>
        /// Initialize Store Service.
        /// </summary>
        public StoreService()
        {
            this.Store = new Store();
        }
        
        /// <summary>
        /// Set theme by theme type and invoke subscribe events.
        /// </summary>
        /// <param name="type">Theme type</param>
        public void SetTheme(ThemeType type)
        {
            this.Store.ThemeType = type;
            this.NotifyStateChanged();
        }

        /// <summary>
        /// Get current theme settings.
        /// </summary>
        /// <returns>Current Theme</returns>
        public ThemeType GetTheme()
        {
            return this.Store.ThemeType;
        }

        /// <summary>
        /// Change notify.
        /// </summary>
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}