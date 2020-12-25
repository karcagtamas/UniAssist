using System.Threading.Tasks;
using UniAssist.Enums;

namespace UniAssist.Services
{
    /// <summary>
    /// Theme Service Interface
    /// </summary>
    public interface IThemeService
    {
        /// <summary>
        /// Set theme
        /// </summary>
        /// <param name="type">Theme type</param>
        /// <returns>Task</returns>
        Task SetTheme(ThemeType type);
    }
}