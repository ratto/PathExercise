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
using System.Collections.Generic;

namespace PathExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string originPath = @"d:\Temp\PathExercise";
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                // let's open the origin file
                fs = new FileStream(originPath + @"\origin.csv", FileMode.Open);
                sr = new StreamReader(fs);

                // the file has some lines, so let's print them on screen to check if everything is working as expected
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                // IO error exception message
                Console.WriteLine("An error ocurred!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }
    }
}
