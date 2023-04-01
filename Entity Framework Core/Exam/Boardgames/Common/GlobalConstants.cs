using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Common
{
    public static class GlobalConstants
    {
        //Boardgame
        public const int BoardgameNameMinLength = 10;
        public const int BoardgameNameMaxLength = 20;
        public const double BoardgameRatingMin = 1;
        public const double BoardgameRatingMax = 10.00;
        public const int BoardgameYearPublishedMin = 2018;
        public const int BoardgameYearPublishedMax = 2023;

        //Seller
        public const int SellerNameMinLength = 5;
        public const int SellerNameMaxLength = 20;
        public const int SellerAddressMinLength = 2;
        public const int SellerAddressMaxLength = 30;
        public const string SellerWebsiteRegularExpression = @"www\.[a-zA-Z0-9\-]+\.com";

        //Creator
        public const int CreatorFirstNameMinLength = 2;
        public const int CreatorFirstNameMaxLength = 7;
        public const int CreatorLastNameMinLength = 2;
        public const int CreatorLastNameMaxLength = 7;
    }
}
