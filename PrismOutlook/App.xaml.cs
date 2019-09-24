using System.ComponentModel;
using PrismOutlook.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using System.Windows.Controls;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Core.Regions;
using PrismOutlook.Modules.Calendar;
using PrismOutlook.Modules.Contacts;
using PrismOutlook.Modules.Mail;

namespace PrismOutlook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
           moduleCatalog.AddModule<MailModule>();
           moduleCatalog.AddModule<ContactsModule>();
           moduleCatalog.AddModule<CalendarModule>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
           base.ConfigureRegionAdapterMappings(regionAdapterMappings);

           regionAdapterMappings.RegisterMapping(typeof(XamOutlookBar), Container.Resolve<XamOutlookBarRegionAdapter>());
           regionAdapterMappings.RegisterMapping(typeof(XamRibbon), Container.Resolve<XamRibbonRegionAdapter>());
      }
    }
}
