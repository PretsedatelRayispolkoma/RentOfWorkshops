using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentOfWorkshopsCore.DBConnection;

namespace MyTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = SQLConnection.GetAllSpaces();

            foreach (var i in list)
                Console.Write(i.TypeOfSpace.Name);
        }
    }
}
