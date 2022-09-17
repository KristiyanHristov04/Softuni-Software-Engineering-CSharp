using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack
    {
        private int[] items;
        private const int InitialCapacity = 4;
        public int Count { get; private set; }
        public CustomStack()
        {
            this.Count = 0;
            this.items = new int[InitialCapacity];
        }
        public void Push(int element)
        {
            if (this.Count == this.items.Length)
            {
                var nextItems = new int[this.items.Length * 2];
                for (int i = 0; i < this.items.Length; i++)
                {
                    nextItems[i] = this.items[i];
                }
                this.items = nextItems;
            }
            this.items[this.Count] = element;
            Count++;
        }
        public int Pop()
        {
            if (this.Count == 0)
            {
                //Throw exception
                throw new ArgumentException("CustomStack is empty");
            }
            var lastIndex = this.Count - 1;
            int last = this.items[lastIndex];
            this.Count--;
            return last;
        }
        public void Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("Stack is empty.");
            }
            int firstElement = this.items[0];
            Console.WriteLine(firstElement);
        }
        public void Contains(int element)
        {
            bool doesExist = false;
            foreach (var number in this.items)
            {
                if (number == element)
                {
                    doesExist = true;
                }
            }
            Console.WriteLine(doesExist);
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var number in this.items)
            {
                sb.Append(number + " ");
            }
            return sb.ToString();
        }
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
        }
    }
}
