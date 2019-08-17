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
            FileStream fs = null;
            StreamReader sr = null;
            List<string> lines = new List<string>();

            try
            {
                // let's open the origin file
                fs = new FileStream(originPath + @"\origin.csv", FileMode.Open);
                sr = new StreamReader(fs);
                


                double price = 0.00;
                int quantity = 0;
                char currentChar = '0';

                // We read the file and store each of it's line in lines list
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine() + ",";
                    lines.Add(line);
                }

                // Now we read each stored line and proccess them accordingly
                foreach (string line in lines)
                {
                    Console.WriteLine(line);

                    Product product = new Product();

                    string[] words = new string[3];
                    int charAt = 0;
                    string word = null;
                    string name = null;

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

                    product.Name = words[0];
                    product.Price = double.Parse(words[1], CultureInfo.InvariantCulture);
                    quantity = int.Parse(words[2]);

                    Console.WriteLine(product.getTotalPrice(quantity));
                    // Console.WriteLine(name + " -> R$" + price.ToString("F2", CultureInfo.InvariantCulture) + " x " + quantity + " = R$" + (price * quantity).ToString("F2", CultureInfo.InvariantCulture));
                    Console.WriteLine();
                }

                /*
                 * Right now it is just printing onscreen:
                 * Input (with a ',' in the end, to make the data process easier)
                 * Name -> price x quantity = total amount (in BRL)
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
