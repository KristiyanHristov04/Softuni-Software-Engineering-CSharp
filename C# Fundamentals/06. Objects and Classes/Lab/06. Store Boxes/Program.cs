using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                string[] commands = input.Split(' ');

                Box box = new Box();

                box.SerialNumber = Convert.ToInt32(commands[0]);
                box.Item.Name = commands[1];
                box.ItemQuantity = Convert.ToInt32(commands[2]);
                box.PriceForABox = Convert.ToDouble(commands[3]);
                box.Item.Price = box.PriceForABox * box.ItemQuantity;

                boxes.Add(box);                
            }

            List<Box> sortedBox = boxes.OrderByDescending(boxes => boxes.Item.Price).ToList();

            foreach (var box in sortedBox)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.PriceForABox:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.Item.Price:f2}");
            }
        }
    }
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }

        
    }

    class Box
    {
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForABox { get; set; }

        public Box()
        {
            Item = new Item();
        }
    }
}
