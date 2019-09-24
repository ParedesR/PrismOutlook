using System;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismOutlook.Core.ViewModels
{
   public class ViewModelBase : BindableBase, IConfirmNavigationRequest
   {
      public virtual void OnNavigatedTo(NavigationContext navigationContext)
      {
         
      }


      public virtual bool IsNavigationTarget(NavigationContext navigationContext)
      {
         return true;
      }

      public virtual void OnNavigatedFrom(NavigationContext navigationContext)
      {
         
      }

      public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
      {
         continuationCallback(true);
      }
   }
}
