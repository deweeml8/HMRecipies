using System;
using Xamarin.Forms;

namespace HMRecipies.Helpers
{
    public class ThemeManager
    {
        public ThemeManager()
        {
        }
        public static void ChangeTheme()
        {
            Application.Current.Resources.MergedDictionaries.Add(new Styling.Themes.Base());
        }
    }
}
