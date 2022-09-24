using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int currentIndex;
        public ListyIterator(params T[] elements)
        {
            this.collection = new List<T>(elements);
            this.currentIndex = 0;
        }

        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                this.currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.currentIndex + 1 <= this.collection.Count - 1)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine(this.collection[currentIndex]);
        }
        public void PrintAll()
        {
            List<T> newList = new List<T>();
            foreach (T element in this.collection)
            {
                newList.Add(element);
            }
            Console.WriteLine(String.Join(" ", newList));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.collection)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
