/*
 
 Author: Allison Drake
 Date 11/3/2019
 CTEC 135: Microsoft Software Development with C#
 Programming Assignment 5 - LINQ and Unit Testing
 Problem 2: XML Using LINQ

 The Main() Method should call the methods described below (ref appendix B)
 1. Create a static method that creates an XML document and saves it. pgs 3 and 10
 2. Create a static method that creates an XML document from an array and saves it pg 12
 3. Create a static method that loads an XML document and print it to the screen.
 You can load the doc created in 2 above. pg 13. (load document and print-ignore parsing)
 At minimum implement example in Appendix B. Extra points for a different example 
 than the book. Bonus points for something more complex. 

 IPO:
 Description: XML document building exercise using LINQ
 INPUTS: Paint List with types and quantities. Instrument List with make, model, and type
 PROCESSES: using System.XML, System.XML.LINQ to use XDocuments, XComments, XElements,
    and methods that contain lists. Lists are saved using .Save and file loaded by
    calling the load method, then prints the contents. 
 OUTPUTS: Output 1 is the list of paints and Output 2 is the list of instruments

 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace Prob2
{
    class Program
    {
        #region Main() with call methods
        static void Main(string[] args)
        {
            //call CreateXmlDoc method to save list to memory
            CreateXmlDoc();
            //call MakeXmlDocFromArray method to save list to memory
            MakeXmlDocFromArray();
            //call LoadXml mehthod to load and print the previous lists
            LoadXml();
        }
        #endregion

        #region 1. Create a static method that creates an XML document and saves it
        static void CreateXmlDoc()
        {
            //use XDocument to create a new XDocument
            XDocument paintListFile =
            new XDocument(
            //populate the document using XComments, XElements and XAttributes
            new XComment("List of Paints"),
            new XElement("My_Paint_List",
            new XElement("Blues", new XAttribute("Total_Colors", "3"),
            new XElement("Light_Blue", new XAttribute("Quantity", "2")),
            new XElement("Dark_Blue", new XAttribute("Quantity", "7")),
            new XElement("Primary_Blue", new XAttribute("Quantity", "10"))
            ),
            new XElement("Greens", new XAttribute("Total_Colors", "6"),
            new XElement("Light_Green", new XAttribute("Quantity", "8")),
            new XElement("Dark_Green", new XAttribute("Quantity", "2")),
            new XElement("Forest_Green", new XAttribute("Quantity", "1")),
            new XElement("Kelly_Green", new XAttribute("Quantity", "3")),
            new XElement("Moss_Green", new XAttribute("Quantity", "9")),
            new XElement("Blue-Green", new XAttribute("Quantity", "1"))
            ),
            new XElement("Whites_and_Blacks", new XAttribute("Total_Colors", "5"),
            new XElement("Neutral_Grey", new XAttribute("Quantity", "3")),
            new XElement("Black", new XAttribute("Quantity", "8")),
            new XElement("White", new XAttribute("Quantity", "10")),
            new XElement("Bright_White", new XAttribute("Quantity", "15")),
            new XElement("Dark_Gray", new XAttribute("Quantity", "4"))
            ),
            new XElement("Reds", new XAttribute("Total_Colors", "3"),
            new XElement("Primary_Red", new XAttribute("Quantity", "2")),
            new XElement("Crimson", new XAttribute("Quantity", "1")),
            new XElement("Burgundy", new XAttribute("Quantity", "3"))
            ),
            new XElement("Yellows", new XAttribute("Total_Colors", "2"),
            new XElement("Primary_Yellow", new XAttribute("Quantity", "2")),
            new XElement("Banana_Yellow", new XAttribute("Quantity", "1"))
            ),
            new XElement("Oranges", new XAttribute("Total_Colors", "2"),
            new XElement("Orange", new XAttribute("Quantity", "1")),
            new XElement("Tan", new XAttribute("Quantity", "2"))
            ),
            new XElement("Purples", new XAttribute("Total_Colors", "2"),
            new XElement("Violet", new XAttribute("Quantity", "3")),
            new XElement("Purple", new XAttribute("Quantity", "8"))
            )
            )
            );
            // Save to disk.
            paintListFile.Save("PaintList.xml");
        }
        #endregion

        #region 2. Create a static method that creates an XML document from an array and
        // saves it
        static void MakeXmlDocFromArray()
        {
            // Create an anonymous array of anonymous types and populate it
            var instruments = new[]
            {
                new { Type = "Baritone Saxophone", Make = "Selmer", Model = "Series II"},
                new { Type = "Trumpet", Make = "Yamaha", Model = "Stradivarian" },
                new { Type = "Clarinet", Make = "Buffet", Model = "Crampon E11" },
                new { Type = "Recorder", Make = "West Music", Model = "Harmony"},
                new { Type = "Keyboard", Make = "Yamaha", Model = "S88"},
                new { Type = "Upright_Piano", Make = "Bechstein", Model = "Concert 8"},
                new { Type = "Drumset", Make = "Ludwig", Model = "LC175"},
                new { Type = "Tambourine", Make = "Unknown", Model = "Unknown"}
            };
            //use XDocument to create a new XDocument
            XElement vehicleDoc =
            new XElement("Instrument_List",
            //populate the document using XComments, XElements and XAttributes
            //and the array above
            from instrument in instruments
            select new XElement("Instrument", new XElement("Type", 
            instrument.Type), new XElement("Make", instrument.Make), 
            new XElement("Model", instrument.Model))
            );
            Console.WriteLine();
            // Save to disk.
            vehicleDoc.Save("Instruments.xml");
        }
        #endregion 

        #region  3. Create a static method that loads an XML document 
        // and print it to the screen
        static void LoadXml()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("    Paint List is Loaded Below");
            Console.WriteLine("-----------------------------------");
            //load instruments document
            XDocument loadDoc = XDocument.Load("PaintList.xml");
            //print instruments document
            Console.WriteLine(loadDoc);
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("  Instrument List is Loaded Below");
            Console.WriteLine("-----------------------------------");
            //load paint list
            XDocument loadDoc2 = XDocument.Load("Instruments.xml");
            //print paint list
            Console.WriteLine(loadDoc2);
        }
        #endregion
    }
}
