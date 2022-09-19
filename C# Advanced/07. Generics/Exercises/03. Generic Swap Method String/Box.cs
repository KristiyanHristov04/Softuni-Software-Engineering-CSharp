using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Generic_Swap_Method_String
{
    public class Box<T>
    {
        public T Element { get; }
        public List<T> ElementsList { get; }
        public Box(T element)
        {
            this.Element = element;
        }
        public Box(List<T> elementsList)
        {
            this.ElementsList = elementsList;
        }
        public void Swap(List<T> elementsList, int index01, int index02)
        {
            T firstElement = elementsList[index01];
            elementsList[index01] = elementsList[index02];
            elementsList[index02] = firstElement;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T element in ElementsList)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
