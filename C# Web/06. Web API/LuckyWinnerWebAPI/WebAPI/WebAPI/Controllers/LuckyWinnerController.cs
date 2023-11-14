using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuckyWinnerController : ControllerBase
    {
        private static readonly List<Person> People = new List<Person>()
        {
            new Person("Kristiyan", "Krasimirov", "Hristov", 19, "Veliko Tarnovo", "Bulgaria", true),
            new Person("Maria", "Magdalena", "Ivanova", 22, "Melnik", "Bulgaria", false)
        };

        [HttpGet]
        public IActionResult GetWinner()
        {
            int luckyWinner = Random.Shared.Next(0, People.Count);
            return Ok(People[luckyWinner]);
        }

        [HttpPost]
        public IActionResult PostPerson(string firstName, string middleName, string lastName, int age, string town, string country, bool isMale)
        {
            People.Add(new Person(firstName, middleName, lastName, age, town, country, isMale));
            return Ok();
        }

        [HttpPut]
        public IActionResult PutPerson(int id, string firstName, string middleName, string lastName, int age, string town, string country, bool isMale)
        {
            Person? personToEdit = People.FirstOrDefault(p => p.PersonId == id);
            if (personToEdit == null)
            {
                return NotFound();
            }

            personToEdit.FirstName = firstName;
            personToEdit.MiddleName = middleName;
            personToEdit.LastName = lastName;
            personToEdit.Age = age;
            personToEdit.Town = town;
            personToEdit.Country = country;
            personToEdit.IsMale = isMale;

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletePerson(int id)
        {
            Person? personToDelete = People.FirstOrDefault(p => p.PersonId == id);
            if (personToDelete == null)
            {
                return NotFound();
            }

            People.Remove(personToDelete);

            return Ok();
        }
    }
}
