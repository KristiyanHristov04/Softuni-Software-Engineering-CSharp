using System;
using System.Collections.Generic;
using System.Text;
namespace CollectionHierarchy
{
    using Interfaces;
    using System.Linq;

    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> data;
        public AddRemoveCollection()
        {
            this.data = new List<string>();
        }
        public int Add(string item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string lastElement = this.data.LastOrDefault();
            if (lastElement != null)
            {
                this.data.Remove(lastElement);
            }
            return lastElement;
        }
    }
}
