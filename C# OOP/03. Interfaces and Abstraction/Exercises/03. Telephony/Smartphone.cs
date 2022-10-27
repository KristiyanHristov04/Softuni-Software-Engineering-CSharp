using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    internal class Smartphone : ICallable, IBrowseable
    {
        public string URLOrPhoneNumber { get; private set; }
        public Smartphone(string URLOrPhoneNumber)
        {
            this.URLOrPhoneNumber = URLOrPhoneNumber;
        }
        public void Browse()
        {
            Console.WriteLine($"Browsing: {this.URLOrPhoneNumber}!");
        }

        public void Call()
        {
            Console.WriteLine($"Calling... {this.URLOrPhoneNumber}");
        }
    }
}
