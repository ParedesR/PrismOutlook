using PrismOutlook.Modules.Mail.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Modules.Mail.Menus;


namespace PrismOutlook.Modules.Mail
{
    public class MailModule : IModule
    {
       private readonly IRegionManager _regionManager;

       public MailModule(IRegionManager regionManager)
       {
          _regionManager = regionManager;
       }

       public void OnInitialized(IContainerProvider containerProvider)
       {
          
          _regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(HomeTab));
          _regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(MailGroup));
      }

       public void RegisterTypes(IContainerRegistry containerRegistry)
       {
            
       }
    }
}