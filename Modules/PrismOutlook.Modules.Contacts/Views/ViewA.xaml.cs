using System.Windows.Controls;
using PrismOutlook.Core;
using PrismOutlook.Core.Attributes;
using PrismOutlook.Modules.Contacts.Menus;

namespace PrismOutlook.Modules.Contacts.Views
{
   /// <summary>
   /// Interaction logic for ViewA.xaml
   /// </summary>
   [DependentView(RegionNames.RibbonRegion, typeof(HomeTab))]
   public partial class ViewA : UserControl
    {
        public ViewA()
        {
            InitializeComponent();
        }
    }
}
