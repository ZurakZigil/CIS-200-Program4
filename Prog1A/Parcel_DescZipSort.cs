// Program 4
// CIS 200-01
// Fall 2019
// By: M9888
// Due: 11/25/2019

// File: Parcel_DescZipSort.cs
// This implements a sorting algorthm to sort by
// Destination ZIP (descending)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class Parcel_DescZipSort : Comparer<Parcel>
    {
        // Precondition:  None
        // Postcondition: Reverses natural time order, so descending
        //                When p1 < p2, method returns positive #
        //                When p1 == p2, method returns zero
        //                When p1 > p2, method returns negative #
        public override int Compare(Parcel p1, Parcel p2)
        {
            // Ensure correct handling of null values (in .NET, null less than anything)
            if (p1.DestinationAddress.Zip == 0 && p2.DestinationAddress.Zip == 0) // Both null?
                return 0;                 // Equal

            if (p1.DestinationAddress.Zip == 0) // only p1 is null?
                return -1;  // null is less than any actual time

            if (p2.DestinationAddress.Zip == 0) // only p2 is null?
                return 1;   // Any actual time is greater than null

            return (-1) * p1.DestinationAddress.Zip.CompareTo(p2.DestinationAddress.Zip); // Reverses natural order, so descending
        }
    }
}
