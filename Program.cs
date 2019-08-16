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
using System.Globalization;
using PathExercise;

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
                int charAt = 0;
                string[] words = new string[3];
                string word = null;
                string name = null;
                double price = 0.00;
                int quantity = 0;
                char currentChar = '0';

                string line = sr.ReadLine() + ",";
                Console.WriteLine(line);

                // Now let's split the whole line into smaller pieces
                do
                {
                    currentChar = line[charAt];
                    if (currentChar != ',')
                    {
                        Console.WriteLine(currentChar + @" -> " + charAt);
                        word += currentChar;
                        charAt++;
                    }
                    else
                    {
                        if (words[0] == null)
                        {
                            words[0] = word;
                            word = null;
                        }
                        else if (words[1] == null)
                        {
                            words[1] = word;
                            word = null;
                        }
                        else
                        {
                            words[2] = word;
                            word = null;
                        }

                        charAt++;
                    }
                }
                while (charAt < line.Length);
                Console.WriteLine();

                name = words[0];
                price = double.Parse(words[1], CultureInfo.InvariantCulture);
                quantity = int.Parse(words[2]);

                Console.WriteLine(name + " -> " + price.ToString() + " x " + quantity.ToString() + " = " + (price * quantity), "F2", CultureInfo.InvariantCulture);
                
                /*
                // the file has some lines, so let's print them on screen to check if everything is working as expected
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
                */
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
