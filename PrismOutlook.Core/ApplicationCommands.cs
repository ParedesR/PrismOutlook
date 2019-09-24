using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace PrismOutlook.Core
{
   public interface IApplicationCommands
   {
      CompositeCommand NavigateCommand { get; }

   }


   public class ApplicationCommands : IApplicationCommands
   {
      private CompositeCommand _navigateCommand;

      public CompositeCommand NavigateCommand { get; } = new CompositeCommand();
   }
}
