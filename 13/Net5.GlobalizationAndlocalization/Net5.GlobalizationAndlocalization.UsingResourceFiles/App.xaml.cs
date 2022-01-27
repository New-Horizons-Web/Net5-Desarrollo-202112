
using System.Globalization;
using System.Windows;

namespace Net5.GlobalizationAndlocalization.UsingResourceFiles
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CultureInfo.CurrentUICulture =
                CultureInfo.CreateSpecificCulture("sv");
        }
    }
}
