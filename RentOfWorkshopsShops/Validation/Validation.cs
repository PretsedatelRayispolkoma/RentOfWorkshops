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
    }
}
