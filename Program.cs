/*
 * Path usage exercise:
 * This is just an exercise about reading some data 
 * inside a csv file (d:\Temp\PathExercise\origin.csv), 
 * process the read data and output it in a new file 
 * (d:\Temp\PathExercise\out\summary.csv).
 * 
 */

using System;
using System.IO;

namespace PathExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string originPath = @"d:\Temp\PathExercise";

            try
            {

            }
            catch (IOException e)
            {
                // IO error exception message
                Console.WriteLine("An error ocurred!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
