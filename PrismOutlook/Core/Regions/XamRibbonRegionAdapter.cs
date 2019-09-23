using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infragistics.Windows.Ribbon;
using Prism.Regions;

namespace PrismOutlook.Core.Regions
{
   public class XamRibbonRegionAdapter : RegionAdapterBase<XamRibbon>
   {
      public XamRibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) :base(regionBehaviorFactory)
      {
      }


      protected override void Adapt(IRegion region, XamRibbon regionTarget)
      {
         if(region == null) throw new ArgumentNullException(nameof(region));
         if(regionTarget == null) throw new ArgumentNullException(nameof(regionTarget));

         region.Views.CollectionChanged += ((s, e) =>
         {
            switch (e.Action)
            {
               case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
               {
                  foreach (var view in e.NewItems)
                  {
                     AddViewToRegion(view, regionTarget);
                  }

                  break;
               }

               case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
               {
                  foreach (var view in e.OldItems)
                  {
                     RemoveViewFromRegion(view, regionTarget);
                  }

                  break;
               }
            }
         });
      }


      protected override IRegion CreateRegion()
      {
         return new SingleActiveRegion();
      }


      static void AddViewToRegion(object view, XamRibbon xamRibbon)
      {
         if (view is RibbonTabItem ribbonTabItem)
         {
            xamRibbon.Tabs.Add(ribbonTabItem);
         }
      }

      static void RemoveViewFromRegion(object view, XamRibbon xamRibbon)
      {
         if (view is RibbonTabItem ribbonTabItem)
         {
            xamRibbon.Tabs.Remove(ribbonTabItem);
         }
      }
   }
}
