using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    using Common.Constants;

    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get { return id; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                id = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                manufacturer = value;
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                model = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get { return overallPerformance; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                overallPerformance = value;
            }
        }

        public override string ToString()
        => String.Format(SuccessMessages.ProductToString, $"{OverallPerformance:f2}", $"{Price:f2}", this.GetType().Name, Manufacturer, Model, Id);
    }
}
