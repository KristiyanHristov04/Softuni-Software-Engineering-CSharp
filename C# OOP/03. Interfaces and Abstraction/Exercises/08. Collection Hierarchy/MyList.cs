using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    using Interfaces;
    using System.Linq;

    public class MyList : IMyList
    {
        private readonly List<string> data;
        public MyList()
        {
            this.data = new List<string>(); 
        }
        public int Used => this.data.Count;

        public int Add(string item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string elementToRemove = this.data.FirstOrDefault();
            if (elementToRemove != null)
            {
                this.data.Remove(elementToRemove);
            }
            return elementToRemove;
        }
    }
}
