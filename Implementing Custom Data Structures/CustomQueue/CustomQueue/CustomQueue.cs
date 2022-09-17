using System;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    internal class CustomQueue
    {
        private int[] items;
        private const int InitialCapacity = 4;
        public int Count { get; private set; }
        public CustomQueue()
        {
            this.Count = 0;
            this.items = new int[InitialCapacity];
        }

        public void Enqueue(int element)
        {
            if (this.Count == this.items.Length)
            {
                IncreaseSize();
            }
            this.items[Count] = element;
            this.Count++;
        }
        public void Dequeue()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("CustomQueue is Empty.");
            }
            int[] copy = new int[this.Count - 1];
            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = this.items[i + 1];
            }
            this.items = copy;
            this.Count--;
        }
        public void Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("CustomQueue is Empty. This operation cannot be executed because the CustomQueue is empty.");
            }
            Console.WriteLine(this.items[0]);
        }
        public void Clear()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("This command cannot be executed because the CustomQueue is empty already.");
            }
            this.Count = 0;
            this.items = new int[InitialCapacity];
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
        private void IncreaseSize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
    }
}
