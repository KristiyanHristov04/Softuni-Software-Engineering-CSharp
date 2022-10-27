using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string URLOrPhoneNumber { get; private set; }

        public StationaryPhone(string URLOrPhoneNumber)
        {
            this.URLOrPhoneNumber = URLOrPhoneNumber;
        }

        public void Call()
        {
            Console.WriteLine($"Dialing... {this.URLOrPhoneNumber}");
        }
    }
}
