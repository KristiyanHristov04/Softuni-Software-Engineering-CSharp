namespace SeminarHub.Common
{
    public static class DataConstants
    {
        public static class Seminar
        {
            public const int TopicMinLength = 3;
            public const int TopicMaxLength = 100;

            public const int LecturerMinLength = 5;
            public const int LecturerMaxLength = 60;

            public const int DetailsMinLength = 10;
            public const int DetailsMaxLength = 500;

            public const string DateAndTimeFormat = "dd/MM/yyyy HH:mm";

            //Not required for the exam but I decided to add since user will have
            //client-side validation that way otherwise is not obvious what is wrong.
            public const string DateFormatRegex = @"[0-9]{2}\/[0-9]{2}\/[0-9]{4}\ [0-9]{2}\:[0-9]{2}";

            public const int DurationMin = 30;
            public const int DurationMax = 180;
        }

        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }
    }
}
