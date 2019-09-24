using System;

namespace PrismOutlook.Core.Attributes
{
   [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
   public class DependentViewAttribute : Attribute
   {
      public string RegionName { get; set; }
      public  Type DependentViewType { get; set; }

      public DependentViewAttribute(string regionName, Type dependentViewType)
      {
         if (string.IsNullOrEmpty(regionName))
         {
            throw new ArgumentNullException(nameof(regionName));
         }

         if (dependentViewType == null)
         {
            throw new ArgumentNullException(nameof(dependentViewType));
         }

         RegionName = regionName;
         DependentViewType = dependentViewType;
      }
   }
}
