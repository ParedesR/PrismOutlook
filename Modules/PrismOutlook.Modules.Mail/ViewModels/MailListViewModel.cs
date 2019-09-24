using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Regions;
using PrismOutlook.Core.ViewModels;

namespace PrismOutlook.Modules.Mail.ViewModels
{
   public class MailListViewModel : ViewModelBase, INavigationAware
   {
      private string _title = "Default";

      public string Title
      {
         get => _title;
         set => SetProperty(ref _title, value);
      }


      public MailListViewModel()
      {

      }

      public override void OnNavigatedTo(NavigationContext navigationContext)
      {
         Title = navigationContext.Parameters.GetValue<string>("id");
      }
   }
}
