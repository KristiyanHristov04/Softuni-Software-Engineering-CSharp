using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace OnlineShop.Models.Products.Peripherals
{
    using Common.Constants;

    public abstract class Peripheral : Product, IPeripheral
    {
        public Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            ConnectionType = connectionType;
        }

        public string ConnectionType { get; private set; }

        public override string ToString()
        => base.ToString() + String.Format(SuccessMessages.PeripheralToString, ConnectionType);
    }
}
