using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeisterMask.Common
{
    public static class GlobalConstants
    {
        //Employee
        public const string EmployeeUsernameRegularExpression = @"[a-zA-Z0-9]{3,}";
        public const int EmployeeUsernameMinLength = 3;
        public const int EmployeeUsernameMaxLength = 40;
        public const string EmployeePhoneRegularExpression = @"[0-9]{3}\-[0-9]{3}\-[0-9]{4}";

        //Project
        public const int ProjectNameMinLength = 2;
        public const int ProjectNameMaxLength = 40;

        //Task
        public const int TaskNameMinLength = 2;
        public const int TaskNameMaxLength = 40;
    }
}
