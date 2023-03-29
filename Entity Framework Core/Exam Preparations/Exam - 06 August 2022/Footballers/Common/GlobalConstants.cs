using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Common
{
    public static class GlobalConstants
    {
        //Footballer
        public const int FootballerNameMinLength = 2;
        public const int FootballerNameMaxLength = 40;

        //Team
        public const int TeamNameMinLength = 3;
        public const int TeamNameMaxLength = 40;
        public const string TeamNameRegularExpression = @"[a-zA-Z0-9\s\.\-]{3,}";
        public const int TeamNationalityMinLength = 2;
        public const int TeamNationalityMaxLength = 40;

        //Coach
        public const int CoachNameMinLength = 2;
        public const int CoachNameMaxLength = 40;

    }
}
