using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;

        public double Height
        {
            get { return height; }
            private set { height = value; }
        }
        private double width;

        public double Width
        {
            get { return width; }
            private set { width = value; }
        }
        public Rectangle(double height, double width)
        {
            this.Width = width;
            this.Height = height;
        }
        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }
        public override double CalculatePerimeter()
        {
            return 2 * this.Height + 2 * this.Width;
        }
        public override string Draw()
        {
            return base.Draw() + $"{this.GetType().Name}";
        }
    }
}
