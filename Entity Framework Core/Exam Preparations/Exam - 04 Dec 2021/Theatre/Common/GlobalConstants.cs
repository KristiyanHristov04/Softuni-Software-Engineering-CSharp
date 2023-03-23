using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Common
{
    public static class GlobalConstants
    {
        //Theatre
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const sbyte TheatreNumberOfHallsMin = 1;
        public const sbyte TheatreNumberOfHallsMax = 10;
        public const sbyte TheatreDirectorMinLength = 4;
        public const sbyte TheatreDirectorMaxLength = 30;

        //Play
        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;
        public const double PlayRatingMin = 0.00f;
        public const double PlayRatingMax = 10.00f;
        public const int PlayDescriptionMaxLength = 700;
        public const int PlayScreenWriterMinLength = 4;
        public const int PlayScreenWriterMaxLength = 30;

        //Cast
        public const int CastFullNameMinLength = 4;
        public const int CastFullNameMaxLength = 30;
        public const string CastPhoneNumberRegulaxExpression = @"\+44\-[0-9]{2}\-[0-9]{3}\-[0-9]{4}";

        //Ticket
        public const string TicketPriceMin = "1.00";
        public const string TicketPriceMax = "100.00";
        public const sbyte TicketRowNumberMin = 1;
        public const sbyte TicketRowNumberMax = 10;
    }
}
