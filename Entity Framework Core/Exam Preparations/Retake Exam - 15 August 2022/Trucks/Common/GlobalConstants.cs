using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Common
{
    public static class GlobalConstants
    {
        //Truck
        public const string TruckRegistrationNumberRegularExpression = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const int TruckVinNumberLength = 17;
        public const int TruckTankCapacityMin = 950;
        public const int TruckTankCapacityMax = 1420;
        public const int TruckCargoCapacityMin = 5000;
        public const int TruckCargoCapacityMax = 29000;

        //Client
        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 40;
        public const int ClientNationalityMinLength = 2;
        public const int ClientNationalityMaxLength = 40;

        //Despatcher
        public const int DespatcherNameMinLength = 2;
        public const int DespatcherNameMaxLength = 40;
    }
}
