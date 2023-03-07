using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext dbContext = new SoftUniContext())
            {
                string result = RemoveTown(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string RemoveTown(SoftUniContext context)
        {
            var townToBeRemoved = context.Towns
                .First(t => t.Name == "Seattle");

            var addressesFromSeattle = context.Addresses
                .Where(a => a.TownId == townToBeRemoved.TownId);

            int addressesCount = addressesFromSeattle.Count();

            var employees = context.Employees
                .Where(e => addressesFromSeattle.Any(a => a.AddressId == e.AddressId));

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesFromSeattle);

            context.Towns.Remove(townToBeRemoved);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
