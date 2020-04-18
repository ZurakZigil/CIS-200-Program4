// Program 4
// CIS 200-01
// Fall 2019
// By: M9888
// Due: 11/25/2019

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.
// Sorting functionality has been added to display several different pre-defined sorts.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ", "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321", "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7", "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("[Redacted]", "000 X Street", "Layer 10", "Duckwater", "NV", 00001); // Test Address 5
            Address a6 = new Address("Mike", "1 Mike Street", "The Mike Zone", "Mike Peak", "MN", 75892); // Test Address 6

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15, 85, 7.50M);   // Next Day test object
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, 80.5, TwoDayAirPackage.Delivery.Saver);// Two Day test object
            Letter letter2 = new Letter(a3, a5, 0.00M);                            // Letter test object
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a3, a2, 5, 4, 2, 8, TwoDayAirPackage.Delivery.Saver);// Two Day test object
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a4, a6, 50, 40, 20, 80, TwoDayAirPackage.Delivery.Early);// Two Day test object
            Letter letter3 = new Letter(a1, a2, 0.58M);                            // Letter test object
            Letter letter4 = new Letter(a3, a4, 9.00M);                            // Letter test object
            Letter letter5 = new Letter(a5, a6, 1.25M);                            // Letter test object
            Letter letter6 = new Letter(a6, a5, 125.125M);                            // Letter test object

            List<Parcel> parcels = new List<Parcel>();      // List of test parcels

            // Populate list
            parcels.Add(letter1);   // 1
            parcels.Add(gp1);       // 2
            parcels.Add(ndap1);     // 3
            parcels.Add(tdap1);     // 4
            parcels.Add(letter2);   // 5
            parcels.Add(tdap2);     // 6
            parcels.Add(tdap3);     // 7
            parcels.Add(letter3);   // 8
            parcels.Add(letter4);   // 9
            parcels.Add(letter5);   // 10
            parcels.Add(letter6);   // 11


            // ------------------------------------------------------------- Original List

            // no sorting
            WriteLine("Original List:");
            WriteLine("====================");
            sortedList(parcels); // lists parcels

            // ------------------------------------------------------------- Default Sort: ascending cost

            parcels.Sort(); // default sort
            WriteLine("Cost Ascending (Default Sort):");
            WriteLine("====================");
            sortedList(parcels); // lists parcels based on default sort

            // ------------------------------------------------------------- Descending ZIP

            parcels.Sort(new Parcel_DescZipSort()); // sorts based on the specified class (descending destination zip)
            WriteLine("Destination Zip Descending:");
            WriteLine("====================");
            sortedList(parcels); // lists parcels based on specified sort above

            // ------------------------------------------------------------- Extra Credit

            parcels.Sort(new Parcel_TypeCostSort()); // sorts based on the specified class (asc. type, desc. cost)
            WriteLine("Type Ascending, Cost Descending:");
            WriteLine("====================");
            sortedList(parcels); // lists parcels based on specified sort above
        }

        // Precondition:  None
        // Postcondition: Lists out all the items that have been added to the list that is specified
        public static void sortedList(List<Parcel> list)
        {
            string NL = Environment.NewLine; // NewLine shortcut

            // asks the user how they woudl liek the data displayed
            WriteLine($"Would you like the short (1) or long version (2)? {NL}" +
                $"Tip: Short is easier for grading.");

            string reply = ReadLine();

            if (reply == "1") // gives a short view to ease grading
            {
                foreach (Parcel p in list)
                {
                    WriteLine($"Type: {p.GetType()} " +
                        $"{NL}Cost: {p.CalcCost():C2} " +
                        $"{NL}Zip: {p.DestinationAddress.ZipToString()}");

                    WriteLine($"{NL}");
                }
            }
            // gives all the details of the parcel
            else foreach (Parcel p in list) // else for simplicity sake, so the default is to show all the info
            {
                WriteLine(p);
                WriteLine($"..................................... {p.GetType()}: {p.CalcCost():C2}  Zip: {p.DestinationAddress.ZipToString()}");
                WriteLine($"===================={NL}");
            }
            Pause();
        }



        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
