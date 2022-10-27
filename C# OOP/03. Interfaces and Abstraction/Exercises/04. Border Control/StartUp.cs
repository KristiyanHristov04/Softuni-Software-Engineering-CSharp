using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<AbstractClass> citizensAndRobots = new List<AbstractClass>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 3)
                {
                    string citizenName = tokens[0];
                    int citizenAge = int.Parse(tokens[1]);
                    string citizenID = tokens[2];
                    Citizen newCitizen = new Citizen(citizenName, citizenAge, citizenID);
                    citizensAndRobots.Add(newCitizen);
                }
                else if (tokens.Length == 2)
                {
                    string robotModel = tokens[0];
                    string robotID = tokens[1];
                    Robot newRobot = new Robot(robotModel, robotID);
                    citizensAndRobots.Add(newRobot);
                }
            }
            string fakeId = Console.ReadLine();
            List<AbstractClass> fakeCitizensAndRobotsIds = new List<AbstractClass>();

            foreach (var item in citizensAndRobots)
            {
                string lastIdNumbers = item.Id.Substring(item.Id.Length - fakeId.Length);
                if (lastIdNumbers == fakeId)
                {
                    fakeCitizensAndRobotsIds.Add(item);
                }
            }

            foreach (var item in fakeCitizensAndRobotsIds)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
