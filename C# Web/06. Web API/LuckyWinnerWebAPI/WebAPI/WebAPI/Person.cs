namespace WebAPI
{
    public class Person
    {
        private static int personId = 1;
        private int currentPersonId;
        public Person(string firstName, string middleName, string lastName,
            int age, string town, string country, bool isMale)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Age = age;
            this.Town = town;
            this.Country = country;
            IsMale = isMale;
            currentPersonId = personId;
            personId++;
        }

        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string Town { get; set; } = null!;
        public string Country { get; set; } = null!;
        public bool IsMale { get; set; }
        public int PersonId
        {
            get { return this.currentPersonId; }
        }
    }
}
