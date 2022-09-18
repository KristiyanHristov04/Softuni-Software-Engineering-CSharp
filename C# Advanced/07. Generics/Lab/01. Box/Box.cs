using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> List { get; private set; }
        public Box()
        {
            this.List = new List<T>();
        }
        public int Count { get { return List.Count; } }
        public void Add(T element)
        {
            this.List.Insert(0, element);
        }
        public T Remove()
        {
            if (this.List.Count == 0)
            {
                throw new ArgumentException("Box is empty. Invalid Operation.");
            }
            T elementToReturn = this.List[0];
            this.List.RemoveAt(0);
            return elementToReturn;
        }
    }
}
