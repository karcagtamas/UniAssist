using System.Threading.Tasks;
using UniAssist.Enums;

namespace UniAssist.Services
{
    public interface IThemeService
    {
        Task SetTheme(ThemeType type);
    }
}