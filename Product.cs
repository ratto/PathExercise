using System;
using System.Collections.Generic;
using System.Text;

namespace PathExercise
{
    class Product
    {
        private string Name { get; set; }
        private double Price { get; set; }

        public Product()
        {

        }

        public Product (string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
