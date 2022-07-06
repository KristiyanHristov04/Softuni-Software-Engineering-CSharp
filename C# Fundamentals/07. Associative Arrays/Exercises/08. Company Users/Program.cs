using System;
using System.Collections.Generic;
namespace _08._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] commands = input.Split(" -> ");
                string companyName = commands[0];
                string employeeId = commands[1];
                if (result.ContainsKey(companyName))
                {
                    bool isMet = false;
                    foreach (var employee in result)
                    {
                        for (int i = 0; i < employee.Value.Count; i++)
                        {
                            if (employee.Value[i] == employeeId)
                            {
                                isMet = true;
                                break;
                            }
                        }
                    }
                    if (!isMet)
                    {
                        result[companyName].Add(employeeId);
                    }                   
                }
                else
                {
                    result[companyName] = new List<string>() { employeeId };
                }
            }
            foreach (var company in result)
            {
                Console.WriteLine(company.Key);
                for (int i = 0; i < company.Value.Count; i++)
                {
                    Console.WriteLine("-- " + company.Value[i]);
                }
            }
        }
    }
}
