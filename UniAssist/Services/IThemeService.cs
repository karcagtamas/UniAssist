using System.Threading.Tasks;
using UniAssist.Enums;

namespace UniAssist.Services
{
    /// <summary>
    /// Theme Service Interface
    /// </summary>
    public interface IThemeService
    {
        Task SetTheme(ThemeType type);
    }
}