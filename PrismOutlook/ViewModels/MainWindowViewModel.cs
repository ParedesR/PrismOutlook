using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Core.ViewModels;

namespace PrismOutlook.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand<string> _navigateCommand;
        private readonly IRegionManager _regionManger;
        private readonly IApplicationCommands _applicationCommands;

        public DelegateCommand<string> NavigateCommand =>
           _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));
      

        public MainWindowViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands)
        {
           _regionManger = regionManager ?? throw new ArgumentNullException(nameof(regionManager));
           _applicationCommands = applicationCommands ?? throw new ArgumentNullException(nameof(applicationCommands));
           _applicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }


        void ExecuteNavigateCommand(string navigationPath)
        {
           if (string.IsNullOrEmpty(navigationPath))
           {
              throw new ArgumentNullException(nameof(navigationPath));
           }

           _regionManger.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }
   }
}
