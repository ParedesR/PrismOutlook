using System.Windows;
using Infragistics.Themes;
using Infragistics.Windows.Ribbon;

namespace PrismOutlook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : XamRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            ThemeManager.ApplicationTheme = new Office2013Theme();
        }
    }
}
