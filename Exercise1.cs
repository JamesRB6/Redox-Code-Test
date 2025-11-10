using System;
using System.Collections.Generic;
using System.Linq;

namespace Redox_Code_Test
{
    public static class Exercise1
    {
        /// <summary>
        /// Demonstrates LINQ and loop logic:
        /// Generates numbers 1–100, prints even numbers using LINQ, then uses XOR to find numbers divisible by 3 or 5 but not both.
        /// </summary>
        public static void Run()
        {
            try
                {
                // list of int 1 to 100
                List<int> numbers = Enumerable.Range(1, 100).ToList();

                // LINQ to find all even numbers
                Console.WriteLine("Even numbers:");
                var evenNums = numbers.Where(n => n % 2 == 0);
                Console.WriteLine(string.Join(", ", evenNums));

                Console.WriteLine("\nNumbers divisible by 3 or 5, but not both:");
                // List to store results
                List<int> results = new List<int>();
                
                foreach (int num in numbers)
                {
                    bool divisBy3 = num % 3 == 0;
                    bool divisBy5 = num % 5 == 0;
                    
                    // XOR to find numbers divisible by 3 OR 5, but not both
                    if (divisBy3 ^ divisBy5)
                    {
                        results.Add(num);
                    }
                }
                // Print the results, and handle empty list
                if (results.Count == 0)
                        Console.WriteLine("No numbers found matching the condition.");
                else
                    Console.WriteLine(string.Join(", ", results));
            }
            // For any unexpected errors
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}