using System;
using UniAssist.Enums;
using UniAssist.Models;

namespace UniAssist.Services
{
    public class StoreService
    {
        private Store Store { get; set; }
        public event Action OnChange;

        public StoreService()
        {
            this.Store = new Store();
        }
        public void SetTheme(ThemeType type)
        {
            this.Store.ThemeType = type;
            this.NotifyStateChanged();
        }

        public ThemeType GetTheme()
        {
            return this.Store.ThemeType;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}