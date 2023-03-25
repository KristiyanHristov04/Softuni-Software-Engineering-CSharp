using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery.Common
{
    public static class GlobalConstants
    {
        //Country
        public const int CountryNameMinLength = 4;
        public const int CountryNameMaxLength = 60;
        public const int CountryArmySizeMinSize = 50_000;
        public const int CountryArmySizeMaxSize = 10_000_000;

        //Manufacturer
        public const int ManufacturerNameMinLength = 4;
        public const int ManufacturerNameMaxLength = 40;
        public const int ManufacturerFoundedMinLength = 10;
        public const int ManufacturerFoundedMaxLength = 100;

        //Shell
        public const double ShellWeightMin = 2;
        public const double ShellWeightMax = 1_680;
        public const int ShellCaliberMinLength = 4;
        public const int ShellCaliberMaxLength = 30;

        //Gun
        public const int GunWeightMin = 100;
        public const int GunWeightMax = 1_350_000;
        public const double GunBarrelLengthMin = 2.00;
        public const double GunBarrelLengthMax = 35.00;
        public const int GunRangeMin = 1;
        public const int GunRangeMax = 100_000;
    }
}
