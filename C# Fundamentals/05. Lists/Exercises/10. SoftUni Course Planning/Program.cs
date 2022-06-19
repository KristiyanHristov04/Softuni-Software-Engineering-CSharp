using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            List<string> exercises = new List<string>();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                List<string> data = input.Split(':').ToList();

                string operation = data[0];
                string lesson = data[1];

                switch (operation)
                {
                    case "Add":

                        if (!lessons.Contains(lesson))
                        {
                            lessons.Add(lesson);
                        }

                        break;


                    case "Insert":

                        int index = int.Parse(data[2]);

                        if (index >= 0 &&
                            index < lessons.Count &&
                            !lessons.Contains(lesson))
                        {
                            lessons.Insert(index, lesson);
                        }

                        break;


                    case "Remove":

                        lessons.Remove(lesson);
                        exercises.Remove(lesson);

                        break;


                    case "Swap":

                        string secondLesson = data[2];

                        if (lessons.Contains(lesson) &&
                            lessons.Contains(secondLesson))
                        {
                            int firstIndex = lessons.IndexOf(lesson);
                            int secondIndex = lessons.IndexOf(secondLesson);

                            lessons[secondIndex] = lesson;
                            lessons[firstIndex] = secondLesson;
                        }

                        break;

                    case "Exercise":

                        if (lessons.Contains(lesson))
                        {
                            exercises.Add(lesson);
                        }
                        else
                        {
                            lessons.Add(lesson);
                            exercises.Add(lesson);
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            int counter = 1;

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{counter}.{lessons[i]}");
                counter++;

                if (exercises.Contains(lessons[i]))
                {
                    Console.WriteLine($"{counter}.{lessons[i]}-Exercise");
                    counter++;
                }

            }
        }


    }
}