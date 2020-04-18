// Program 4
// CIS 200-01
// Fall 2019
// By: M9888
// Due: 11/25/2019

// File: Parcel.cs
// Parcel serves as the abstract base class of the Parcel hierachy.
// Icomparable functionality has been added in order to allow sorting of the parcel items
// This implements a sorting algorthm to sort by
// Cost (ascending)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Parcel : IComparable<Parcel> // allows for comparing
{
    // Precondition:  None
    // Postcondition: The parcel is created with the specified values for
    //                origin address and destination address
    public Parcel(Address originAddress, Address destAddress)
    {
        OriginAddress = originAddress;
        DestinationAddress = destAddress;
    }

    public Address OriginAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's origin address has been returned
        get;

        // Precondition:  None
        // Postcondition: The parcel's origin address has been set to the
        //                specified value
        set;
    }

    public Address DestinationAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's destination address has been returned
        get;

        // Precondition:  None
        // Postcondition: The parcel's destination address has been set to the
        //                specified value
        set;
    }

    // Precondition:  None
    // Postcondition: The parcel's cost has been returned
    public abstract decimal CalcCost();

    // Precondition:  None
    // Postcondition: A String with the parcel's data has been returned
    public override String ToString()
    {
        string NL = Environment.NewLine; // NewLine shortcut

        return $"Origin Address:{NL}{OriginAddress}{NL}{NL}Destination Address:{NL}" +
            $"{DestinationAddress}{NL}Cost: {CalcCost():C}";
    }

    // Precondition:  None
    // Postcondition: A default sort has been provided so that the 
    //                items can be sorted by cost in ascending order
    public int CompareTo(Parcel p2)
    {
        if (p2 == null) // only p2 is null?
            return 1;   // Anything is greater than null

            return this.CalcCost().CompareTo(p2.CalcCost());        // Use Cost to decide
    }
}
