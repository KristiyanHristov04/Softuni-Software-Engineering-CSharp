using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> people = new List<Person>();

        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }
        
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember(List<Person> people)
        {
            int oldestAge = people.Max(p => p.Age);
            return people.First(p => p.Age == oldestAge);
        }
    }
}
