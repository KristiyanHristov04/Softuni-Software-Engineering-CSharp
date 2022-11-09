using System;

namespace AuthorProblem
{
    [Author("Victor")]
    [Author("Hector")]
    internal class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true )]
    class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
