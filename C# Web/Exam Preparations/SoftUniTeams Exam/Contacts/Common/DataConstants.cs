namespace Contacts.Common
{
    public static class DataConstants
    {
        public static class AplicationUser
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
        }

        public static class Contact
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 5;
            public const int LastNameMaxLength = 50;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PhoneNumberMinLength = 10;
            public const int PhoneNumberMaxLength = 13;
            public const string PhoneNumberRegexPattern = @"[0+359]+[\ \-]?[0-9]{3}[\ \-]?[0-9]{2}[\ \-]?[0-9]{2}[\ \-]?[0-9]{2}";

            public const string WebsiteRegexPattern = @"w{3}\.[a-z0-9\-]+\.bg";
        }
    }
}
