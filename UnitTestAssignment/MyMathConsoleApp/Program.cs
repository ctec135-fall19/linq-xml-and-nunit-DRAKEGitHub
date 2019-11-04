/*
 Author: Allison Drake
 Date 11/3/2019
 CTEC 135: Microsoft Software Development with C#
 Programming Assignment 5 - LINQ and Unit Testing
 Problem 3: Unit Testing

 IPO:
 Description: Replicating UnitTest Lab at Home
 INPUTS: Integers for Mymath and checked functions
 PROCESSES: Add, reference MyMath1 and MyMath2 Methods, Exception
 Handling with Try and catch
 OUTPUTS: Sum of Math 1, Sum of MyMath1 Function, MyMath2 try

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyMathConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" --- MyMath1ConsoleApp MyMath1 Method ---");
            // add code to console app Main and test Add Method
            Console.WriteLine("55  + 2  = {0}", MyMath1.Add((byte)55, (byte)2));

            // test for sum greated than byte at 256
            Console.WriteLine("200 + 80 = {0}", MyMath1.Add(200,80));


            // try for checked
            try
            {
                Console.WriteLine("200  + 80  = {0}", MyMath2.Add((byte) 200, (byte) 80));
            }
            catch(System.OverflowException)
            {
                Console.WriteLine("The total of these number is larger than 256.");
            }
        }
    }
}
