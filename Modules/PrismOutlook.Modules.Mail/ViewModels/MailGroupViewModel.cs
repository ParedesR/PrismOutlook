using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using PrismOutlook.Business;
using PrismOutlook.Core;
using PrismOutlook.Core.ViewModels;

namespace PrismOutlook.Modules.Mail.ViewModels
{
    public class MailGroupViewModel : ViewModelBase
    {
       private ObservableCollection<NavigationItem> _items;
       private DelegateCommand<NavigationItem> _selectedCommand;
       private readonly IApplicationCommands _applicationCommands;

       public ObservableCollection<NavigationItem> Items
       {
          get => _items;
          set => SetProperty(ref _items, value);
       }

       public DelegateCommand<NavigationItem> SelectedCommand =>
          _selectedCommand ?? (_selectedCommand = new DelegateCommand<NavigationItem>(ExecuteSelectedCommand));
      

        public MailGroupViewModel(IApplicationCommands applicationCommands)
        {
           _applicationCommands = applicationCommands ?? throw new ArgumentNullException(nameof(applicationCommands));

           GenerateMenu();
        }


        void GenerateMenu()
        {
           Items = new ObservableCollection<NavigationItem>();
           var root = new NavigationItem() {Caption = "Personal Folder", NavigationPath = "MailList?id=Default"};
           root.Items.Add(new NavigationItem() {Caption = "Inbox", NavigationPath = "MailList?id=Inbox" });
           root.Items.Add(new NavigationItem() { Caption = "Deleted", NavigationPath = "MailList?id=Deleted" });
           root.Items.Add(new NavigationItem() { Caption = "Sent", NavigationPath = "MailList?id=Sent" });

         Items.Add(root);
        }


        void ExecuteSelectedCommand(NavigationItem navigationItem)
        {
           if (navigationItem == null)
           {
              return;
           }

           _applicationCommands.NavigateCommand.Execute(navigationItem.NavigationPath);

        }
    }
}
