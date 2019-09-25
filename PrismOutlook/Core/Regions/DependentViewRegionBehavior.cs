using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using Prism.Ioc;
using Prism.Regions;
using PrismOutlook.Core.Attributes;

namespace PrismOutlook.Core.Regions
{
   public class DependentViewRegionBehavior : RegionBehavior
   {
      private readonly IContainerExtension _container;

      private readonly Dictionary<object, List<DependentViewInfo>> _dependentViewCache;

      public const string BehaviorKey = @"DependentViewRegionBehavior";

      public DependentViewRegionBehavior(IContainerExtension container)
      {
         _container = container;

         _dependentViewCache = new Dictionary<object, List<DependentViewInfo>>();
      }

      protected override void OnAttach()
      {
         Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
      }


      private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
      {
         if (e.Action == NotifyCollectionChangedAction.Add)
         {
            foreach (var newView in e.NewItems)
            {
               var dependentViews = new List<DependentViewInfo>();

               // Check if view already has dependents.  If it does use them, create them otherwise
               if (_dependentViewCache.ContainsKey(newView))
               {
                  dependentViews = _dependentViewCache[newView];
               }
               else
               {
                  var atts = GetCustomAttributes<DependentViewAttribute>(newView.GetType());
                  foreach (var att in atts)
                  {
                     var info = CreateDependentViewInfo(att);
                     if (info.View is ISupportDataContext infoDataContext &&
                         newView is ISupportDataContext viewDataContext)
                     {
                        infoDataContext.DataContext = viewDataContext.DataContext;
                     }

                     dependentViews.Add(info);
                  }

                  _dependentViewCache.Add(newView, dependentViews);
               }
               
               if (!dependentViews.Any())
               {
                  return;
               }

               dependentViews.ForEach(item => Region.RegionManager.Regions[item.RegionName].Add(item.View));
            }

         }
         else if (e.Action == NotifyCollectionChangedAction.Remove)
         {
            foreach (var oldView in e.OldItems)
            {
               if (!_dependentViewCache.ContainsKey(oldView))
               {
                  continue;
               }

               var dependentViews = _dependentViewCache[oldView];
               dependentViews.ForEach(item => Region.RegionManager.Regions[item.RegionName].Remove(item.View));

               // If being permanently removed, remove from cache
               if (!ShouldKeepAlive(oldView))
               {
                  _dependentViewCache.Remove(oldView);
               }
            }
         }
      }


      private bool ShouldKeepAlive(object oldView)
      {
         var regionLifetime = GetViewOrDataContextLifeTime(oldView);

         if (regionLifetime != null)
         {
            return regionLifetime.KeepAlive;
         }

         return true;
      }


      private IRegionMemberLifetime GetViewOrDataContextLifeTime(object view)
      {
         if (view is IRegionMemberLifetime regionMemberLifeTime)
         {
            return regionMemberLifeTime;
         }

         if (view is FrameworkElement frameworkElement)
         {
            return frameworkElement.DataContext as IRegionMemberLifetime;
         }

         return null;
      }

      private DependentViewInfo CreateDependentViewInfo(DependentViewAttribute attribute)
      {
         // Create view instance
         var info = new DependentViewInfo
         {
            RegionName = attribute.RegionName, View = _container.Resolve(attribute.DependentViewType)
         };
         
         return info;
      }

      private static IEnumerable<T> GetCustomAttributes<T>(Type type)
      {
         return type.GetCustomAttributes(typeof(T), true).OfType<T>();
      }
   }
}
