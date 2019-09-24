using System.Windows.Controls;
using PrismOutlook.Core;
using PrismOutlook.Core.Attributes;
using PrismOutlook.Modules.Mail.Menus;

namespace PrismOutlook.Modules.Mail.Views
{
   /// <summary>
   /// Interaction logic for MailList
   /// </summary>
   [DependentView(RegionNames.RibbonRegion, typeof(HomeTab))]
   public partial class MailList : UserControl
   {
      public MailList()
      {
         InitializeComponent();
      }
   }
}
