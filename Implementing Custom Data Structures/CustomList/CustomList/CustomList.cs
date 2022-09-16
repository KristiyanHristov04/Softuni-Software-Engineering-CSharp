using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;
        public int Count { get; private set; }
        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int this[int index]
        {
            get 
            {
                if (index >= this.Count)
                {
                    throw new ArgumentException();
                }
                return items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentException();
                }
                items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var item = this.items[index];
            this.items[index] = default(int);
            this.Shift(index);
            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }

            return item;
        }
        public void Insert(int index, int element)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (items.Length == Count)
            {
                Resize();
            }
            ShiftToRight(index);
            items[index] = element;
            Count++;
        }
        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if ((firstIndex < this.Count || secondIndex < this.Count) && firstIndex >= 0 && secondIndex >= 0)
            {
                int firstNumber = this.items[firstIndex];
                int secondNumber = this.items[secondIndex];

                this.items[firstIndex] = secondNumber;
                this.items[secondIndex] = firstNumber;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Count - 1; i++)
            {
                sb.Append(items[i] + ", ");
            }

            if (Count != 0)
            {
                sb.Append(items[Count - 1]);
            }

            return sb.ToString();
        }
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}
