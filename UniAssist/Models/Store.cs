using UniAssist.Enums;

namespace UniAssist.Models
{
    /// <summary>
    /// Store Model.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Theme type.
        /// </summary>
        public ThemeType ThemeType { get; set; }

        /// <summary>
        /// Initialize store.
        /// </summary>
        public Store()
        {
            this.ThemeType = ThemeType.Light;
        }
    }
}