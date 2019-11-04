/*
 
 Author: Allison Drake
 Date 11/3/2019
 CTEC 135: Microsoft Software Development with C#
 Programming Assignment 5 - LINQ and Unit Testing
 Problem 1: LINQ

 Create a static method that:
 -+ creates an array of strings (the ordering of strings should be random)
 -+ create a LINQ statement that returns the strings that start with a-f
 -+ output the result
 -+ modify the array in such a way that the result will be different
 -+ output the result again
 -+ modify the array in such a way that the result will be different
 -+ capture the result as a List<string< object and return it
 In Main, output the returned result

  IPO:
 Description: Using LINQ Statements Exercise
 INPUTS: PRoduce list with types of produce, additional produce names
 PROCESSES: string arrays printed using a foreach, new produce added to array, builds query
    and creates alpha query results for a-f "AF"
 OUTPUTS: original list, alpha af list, updated produce list 1, alpha af list of update,
    more produce list, alpha list of more produce list, alpha af list
 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initial String setup and query
            // create an array of strings in random order
            string[] produce = {"cauliflower", "apples", "lettuce", "oranges", "mint",
                "carrots", "celery", "radishes", "dragonfruit", "watermelon"};

            // query using LINQ
            Console.WriteLine("*** Original Produce List ***");
            List<string> listResult = QueryOverStrings(produce);

            // output the result of query method
            Console.WriteLine("-From Original Produce List-");
            foreach (string s in listResult)
            {
                Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
            #endregion

            #region Add additional produce
            // add to the string array produce
            string[] newProduce = { "strawberries", "blueberries", "kale", "bananas", 
                "green beans", "garlic", "onions" };
            foreach(string x in newProduce)
            {
                Array.Resize(ref produce, produce.Length + 1);
                produce[produce.Length - 1] = x;
            }

            // Query over the string array produce and print results
            Console.WriteLine("*** Updated Produce List ***");
            List<string> listResult2 = QueryOverStrings(produce);

            Console.WriteLine("-From Updated Produce List-");
            foreach (string ns in listResult2)
            {
                Console.WriteLine("Item: {0}", ns);
            }
            Console.WriteLine();
            #endregion

            #region More Produce Modification
            // add to the string array produce
            string[] moreProduce = { "passionfruit", "pineapple", "cranberries", "dates",
                "grapes", "raspberries", "blackberries" };
            foreach (string x in moreProduce)
            {
                Array.Resize(ref produce, produce.Length + 1);
                produce[produce.Length - 1] = x;
            }
            // Queries over produce and prints the results
            Console.WriteLine("*** More Produce List ***");
            List<string> listResult3 = QueryOverStrings(produce);

            Console.WriteLine("-From More Produce List-");
            foreach (string t in listResult3)
            {
                Console.WriteLine("Item: {0}", t);
            }
            Console.WriteLine();
            #endregion


        }

        // create query and pull a-f results
        static List<string> QueryOverStrings(string [] inputArray)
        {
            // build query
            var subset = from produceName in inputArray
                          where produceName.StartsWith("")
                          orderby produceName
                          select produceName;

            // printResults of original list
            foreach (var s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();

            //capture the result as a List < string < object and return it
            // return results immediate execution a-f
            List<string> alphaAFList = (from produceName in inputArray
                                        where produceName.StartsWith("a") || 
                                        produceName.StartsWith("b") || 
                                        produceName.StartsWith("c") || 
                                        produceName.StartsWith("d") ||
                                        produceName.StartsWith("e") || 
                                        produceName.StartsWith("f")
                                        orderby produceName
                                        select produceName).ToList<string>();
            Console.WriteLine("*** Alpha AF List: ***");
            return alphaAFList;
        }
    }
}
