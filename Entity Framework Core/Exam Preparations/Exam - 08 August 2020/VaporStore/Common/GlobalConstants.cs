using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaporStore.Common
{
    public static class GlobalConstants
    {
        //Game
        public const string GamePriceMinValue = "0.0";
        public const string GamePriceMaxValue = "79228162514264337593543950335";

        //User
        public const int UserUsernameMinLength = 3;
        public const int UserUsernameMaxLength = 20;
        public const string UserFullNameRegularExpression = @"[A-Z]{1}[a-z]+\s[A-Z]{1}[a-z]+";
        public const int UserAgeMinValue = 3;
        public const int UserAgeMaxValue = 103;

        //Card
        public const string CardNumberRegularExpression = @"[0-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4}";
        public const string CardCvcRegularExpression = @"[0-9]{3}";

        //Purchase
        public const string PurchaseProductKeyRegularExpression = @"[A-Z0-9]{4}\-[A-Z0-9]{4}\-[A-Z0-9]{4}";
    }
}
