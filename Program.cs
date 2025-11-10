using System;

namespace Redox_Code_Test
{
    /// <summary>
    /// Main entry point for the Redox Code Test.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1: LINQ Query 
            Console.WriteLine("Exercise One:");
            Exercise1.Run();

            // Exercise 2: Event Scheduler 
            Console.WriteLine("\n\nExercise Two:");
            Exercise2.Run();
        }
    }
}
