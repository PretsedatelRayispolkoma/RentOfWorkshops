using System;
using RentOfWorkshopsCore.DBConnection;

namespace RentOfWorkShopsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = SQLConnection.RentDB.Space;

            foreach (var item in list)
                Console.WriteLine(item.TypeOfSpace + " " + item.House.Number + " " + item.House.Street.Name + " " + item.House.Street.City.Name);
        }
    }
}
