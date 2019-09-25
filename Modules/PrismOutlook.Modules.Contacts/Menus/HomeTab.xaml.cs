using Infragistics.Windows.Ribbon;

namespace PrismOutlook.Modules.Contacts.Menus
{
   /// <summary>
   /// Interaction logic for HomeTab.xaml
   /// </summary>
   public partial class HomeTab 
   {
      public HomeTab()
      {
         InitializeComponent();

         SetResourceReference(StyleProperty, typeof(RibbonTabItem));
      }
   }
}
