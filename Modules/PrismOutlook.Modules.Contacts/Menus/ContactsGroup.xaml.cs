using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Infragistics.Windows.OutlookBar;
using PrismOutlook.Core;

namespace PrismOutlook.Modules.Contacts.Menus
{
   /// <summary>
   /// Interaction logic for ContactsGroup.xaml
   /// </summary>
   public partial class ContactsGroup : OutlookBarGroup, IOutlookBarGroup
   {
      public ContactsGroup()
      {
         InitializeComponent();
      }

      public string DefaultNavigationPath => @"ViewA";
   }
}
