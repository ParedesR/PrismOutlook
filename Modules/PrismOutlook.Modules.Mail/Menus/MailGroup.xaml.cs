using Infragistics.Controls.Menus;
using Infragistics.Windows.OutlookBar;
using PrismOutlook.Business;
using PrismOutlook.Core;

namespace PrismOutlook.Modules.Mail.Menus
{
   /// <summary>
   /// Interaction logic for MailGroup.xaml
   /// </summary>
   public partial class MailGroup : OutlookBarGroup, IOutlookBarGroup
   {
      public MailGroup()
      {
         InitializeComponent();
      }

      public string DefaultNavigationPath
      {
         get
         {
            if (_dataTree.SelectionSettings.SelectedNodes[0] is XamDataTreeNode item)
            {
               return ((NavigationItem)item.Data).NavigationPath;
            }

            return "MailList?id=Default";
         }
      }
   }
}
