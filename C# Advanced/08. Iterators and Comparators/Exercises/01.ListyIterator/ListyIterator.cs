using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int currentIndex;
        public ListyIterator(params T[] elements)
        {
            this.list = new List<T>(elements);
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
            if (this.currentIndex + 1 <= this.list.Count - 1)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine(this.list[currentIndex]);
        }
    }
}
