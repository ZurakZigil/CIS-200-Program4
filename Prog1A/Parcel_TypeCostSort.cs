// Program 4
// CIS 200-01
// Fall 2019
// By: M9888
// Due: 11/25/2019

// File: Parcel_TypeCostSort.cs
// This implements a sorting algorthm to sort by
// firstly by type (ascending) and then by cost (descending)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class Parcel_TypeCostSort : Comparer<Parcel>
    {
        // Precondition:  None
        // Postcondition: Reverses natural time order, so descending
        //                When p1 < p2, method returns positive #
        //                When p1 == p2, method returns zero
        //                When p1 > p2, method returns negative #
        public override int Compare(Parcel p1, Parcel p2)
        {
            // Ensure correct handling of null values (in .NET, null less than anything)
            if (p1.GetType().ToString() == null && p2.GetType().ToString() == null) // Both null?
                return 0;                 // Equal

            if (p1.GetType().ToString() == null) // only p1 is null?
                return -1;  // null is less than any actual time

            if (p2.GetType().ToString() == null) // only p2 is null?
                return 1;   // Any actual time is greater than null 

            if (p1.GetType().ToString() == p2.GetType().ToString()) // if the types match
            {
                return (-1) * p1.CalcCost().CompareTo(p2.CalcCost()); // order by cost descending
            }
            else return p1.GetType().ToString().CompareTo(p2.GetType().ToString()); // otherwise sort by type ascending 
        }
    }
}
