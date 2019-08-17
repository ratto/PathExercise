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

namespace PathExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string originPath = @"d:\Temp\PathExercise";
            Directory.CreateDirectory(originPath + @"\out");
            string targetFile = originPath + @"\out\summary.csv";

            List<string> lines = new List<string>();
            List<string> entries = new List<string>();

            try
            {
                char currentChar = '0';

                using (StreamReader srOrigin = File.OpenText(originPath + @"\origin.csv"))
                {
                    // We read the file and store each of it's line in lines list
                    while (!srOrigin.EndOfStream)
                    {
                        // I insert this ',' in the end of each line so the processor can read the last data
                        string line = srOrigin.ReadLine() + ",";
                        lines.Add(line);
                    }

                    // Now we read each stored line and proccess them accordingly
                    Console.WriteLine("--- DATA PROCCESSING ---");
                    Console.WriteLine();

                    foreach (string line in lines)
                    {
                        Product product = new Product();

                        // variables needed to split each data from origin file
                        string[] words = new string[3];
                        int charAt = 0;
                        string word = null;

                        // In here we split the whole line into data for later proccessing
                        do
                        {
                            currentChar = line[charAt];
                            if (currentChar != ',')
                            {
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

                        // storing data in product
                        product.Name = words[0];
                        product.Price = double.Parse(words[1], CultureInfo.InvariantCulture);
                        product.Quantity = int.Parse(words[2]);

                        Console.WriteLine(product);

                        // storing this product in a new entry
                        entries.Add(product.Name + "," + product.getTotalPrice().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }

                Console.WriteLine();
                Console.WriteLine("--- END OF DATA PROCCESSING ---");
                Console.WriteLine();
                
                // writing each entry inside 'summary.csv' file
                using (StreamWriter swTarget = File.AppendText(targetFile))
                {
                    foreach (string entry in entries)
                    {
                        swTarget.WriteLine(entry);
                    }
                }

                Console.WriteLine("Write ok!"); // output to check if the file was written
                Console.WriteLine();

                Console.WriteLine("--- OUTPUT (summary.csv) ---");
                Console.WriteLine();

                // and then we print the information from 'summary.csv' file
                using (StreamReader srTarget = File.OpenText(targetFile))
                {
                    while (!srTarget.EndOfStream)
                    {
                        Console.WriteLine(srTarget.ReadLine());
                    }
                }

                Console.WriteLine();
                Console.WriteLine("--- END OF FILE ---");

                /*
                 * Right now it is just printing onscreen:
                 * --- DATA PROCCESSING ---
                 * 
                 * Name -> price x quantity = total amount (in BRL)
                 * 
                 * --- END OF DATA PROCCESSING ---
                 * 
                 * Write ok!
                 * 
                 * --- OUTPUT (summary.csv) ---
                 * 
                 * Name,Total vallue
                 * 
                 * --- END OF FILE ---
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
                
            }
        }
    }
}
