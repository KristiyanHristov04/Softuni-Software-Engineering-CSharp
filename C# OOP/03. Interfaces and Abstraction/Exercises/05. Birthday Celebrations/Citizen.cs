using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : AbstractClass, IBirthable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string BirthDate { get; set; }
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }
    }
}
