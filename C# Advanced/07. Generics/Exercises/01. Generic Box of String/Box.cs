using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Generic_Box_of_String
{
    public class Box<T>
    {
        public T Element { get; set; }
        public Box(T value)
        {
            this.Element = value;
        }
        public override string ToString()
        {
            return $"{typeof(T)}: {this.Element}";
        }
    }
}
