using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOfWorkshopsCore.Validation
{
    public static class Validation
    {
        public static void StringValidation(string value)
        {
            string invalidChars = "!@#$%^&*()+=-}{][><?/\\~''";
            foreach (var chr in invalidChars)
            {
                if (value.Contains(chr))
                    throw new Exception("Value contains one of those signs: \n" +
                        "! @ # $ % ^ & * ( ) + \n = } { ] [ > < ? / \\ ' ");
            }
        }

        public static void DateValidation(DateTime dateTime)
        {
            if (DateTime.Now.Year - dateTime.Year < 18)
                throw new Exception("Your age is less than eighteen");
        }

        public static void PhoneValidation(string number)
        {
            if (number[0] != '7' || number[1] != '9' || (number.Length != 11))
                throw new Exception("Phone number example: 79xx'xxx'xx'xx");
        }
    }
}
