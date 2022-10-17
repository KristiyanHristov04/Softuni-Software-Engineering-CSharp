namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input == "Beast!")
                    {
                        break;
                    }

                    string secondInput = Console.ReadLine();
                    string[] tokens = secondInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    int age = Convert.ToInt32(tokens[1]);


                    if (input == "Cat")
                    {
                        string gender = tokens[2];
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    else if (input == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }
                    else if (input == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                    }
                    else if (input == "Dog")
                    {
                        string gender = tokens[2];
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    else if (input == "Frog")
                    {
                        string gender = tokens[2];
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
                
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
