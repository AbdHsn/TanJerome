using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*
 Summeries:
 Application default vaues or constant values are listed here.

 ---> For getting name of constant following structure can be used.
      1. DefaultValues.OrderStatus.Process.ToString() :Recommended
      2. nameof(DefaultValues.OrderStatus.Process); 
      3. Enum.GetName(typeof(DefaultValues), DefaultValues.OrderStatus.Process);

 ---> For getting index value of constant following structure can be used.
      1. (int)DefaultValues.OrderStatus.Process : Recommended
      2. DefaultValues.OrderStatus.Process.GetHashCode()
      3. Convert.ToInt32(DefaultValues.OrderStatus.Process);
 */

namespace POSMVC.Models.SharedModels
{
    public class DefaultValues
    {
        public enum OrderStatus
        {
            Process = 1,
            Approved,
            Rejected,
            Delivered,
            Refunded
        }
    }
}
