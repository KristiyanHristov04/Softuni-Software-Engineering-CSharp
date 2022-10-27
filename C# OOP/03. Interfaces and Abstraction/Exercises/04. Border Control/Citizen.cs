using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : AbstractClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
    }
}
