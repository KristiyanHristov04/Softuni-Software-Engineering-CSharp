using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double InitialPrice = 4.00;
        public Gingerbread(string delicacyName) : base(delicacyName, InitialPrice)
        {

        }
    }
}
