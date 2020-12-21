using UniAssist.Enums;

namespace UniAssist.Models
{
    public class Store
    {
        public ThemeType ThemeType { get; set; }

        public Store()
        {
            this.ThemeType = ThemeType.Light;
        }
    }
}