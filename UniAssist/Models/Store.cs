using ElectronNET.API;
using UniAssist.Enums;

namespace UniAssist.Models
{
    /// <summary>
    /// Store Model.
    /// </summary>
    public class Store
    {
        /// <value>
        /// Theme type.
        /// </value>
        public ThemeType ThemeType { get; set; }
        
        /// <value>
        /// Working directory path.
        /// </value>
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// Initialize store.
        /// </summary>
        public Store()
        {
            this.ThemeType = ThemeType.Light;
        }
    }
}