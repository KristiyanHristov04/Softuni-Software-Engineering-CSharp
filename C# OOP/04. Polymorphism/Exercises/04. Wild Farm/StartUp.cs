using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                Animal animal = null;
                string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = animalInfo[0];
                if (type == "End")
                {
                    break;
                }
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                switch (type)
                {
                    case "Owl":
                        double wingSize = double.Parse(animalInfo[3]);
                        animal = new Owl(name, weight, wingSize);
                        break;
                    case "Hen":
                        wingSize = double.Parse(animalInfo[3]);
                        animal = new Hen(name, weight, wingSize);
                        break;
                    case "Mouse":
                        string livingRegion = animalInfo[3];
                        animal = new Mouse(name, weight, livingRegion);
                        break;
                    case "Dog":
                        livingRegion = animalInfo[3];
                        animal = new Dog(name, weight, livingRegion);
                        break;
                    case "Cat":
                        livingRegion = animalInfo[3]; 
                        string breed = animalInfo[4];
                        animal = new Cat(name, weight, livingRegion, breed);
                        break;
                    case "Tiger":
                        livingRegion = animalInfo[3];
                        breed = animalInfo[4];
                        animal = new Tiger(name, weight, livingRegion, breed);
                        break;
                }

                string[] foodInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodInformation[0];
                int foodQuantity = int.Parse(foodInformation[1]);
                Food food = null;

                switch (foodType)
                {
                    case "Vegetable":
                        food = new Vegetable(foodQuantity);
                        break;
                    case "Fruit":
                        food = new Fruit(foodQuantity);
                        break;
                    case "Meat":
                        food = new Meat(foodQuantity);
                        break;
                    case "Seeds":
                        food = new Seeds(foodQuantity);
                        break;
                }

                animal.ProduceSound();
                animal.Feed(food);
                animals.Add(animal);
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
