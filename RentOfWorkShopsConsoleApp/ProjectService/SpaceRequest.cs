using static RentOfWorkshopsCore.DBConnection.SQLConnection;
using RentOfWorkshopsCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using RentOfWorkshopsCore.DBConnection;

namespace RentOfWorkShopsConsoleApp.ProjectService
{
    internal static class SpaceRequest
    {
        public static void AnswerRequest(string request)
        {
            switch (request)
            {
                case "get_spaces":
                    GetSpaces();
                    break;
                case "add_space":
                    AddSpace();
                    break;
                default:
                    Console.WriteLine("Unknown request. Try again.");
                    break;
            }
        }

        private static void GetSpaces()
        {
            Console.WriteLine();
            foreach(var space in GetAllSpaces())
            {
                Console.WriteLine($"Type of space: {space.TypeOfSpace.Name} \n" +
                    $"Address: {space.House.Street.City.Name}, {space.House.Street.Name}, {space.House.Number} \n" +
                    $"Amount per hout: {space.AmountPerHour} руб./ч \n" +
                    $"Square: {space.Square} кв. м \n" +
                    $"Description: {space.Description} \n" +
                    $"Status: {space.Status.Name}");
                Console.WriteLine();
            }
        }

        private static void AddSpace()
        {
            foreach (var type in GetAllTypesOfSpace())
                Console.WriteLine($"{type.Id} {type.Name}");

            int typeOfSpace = 0;
            bool _toContinue = true;
            while (_toContinue)
            {
                switch (Console.ReadLine())
                {
                    case "1": typeOfSpace = 1;
                        _toContinue = false; break;
                    case "2": typeOfSpace = 2;
                        _toContinue = false; break;
                    case "3": typeOfSpace = 3;
                        _toContinue = false; break;
                    case "4": typeOfSpace = 4;
                        _toContinue = false; break;
                    case "5": typeOfSpace = 5;
                        _toContinue = false; break;
                    default: Console.WriteLine("Use the number from list"); break;
                }
            }

            Console.WriteLine("Address: ");
            Console.Write("\t City: ");
            City city = new City();
            city.Name = Console.ReadLine();

            Console.Write("\t Street: ");
            Street street = new Street();
            street.Name = Console.ReadLine();
            street.CityId = city.Id;

            Console.Write("\t House: ");
            House house = new House();
            house.Number = Console.ReadLine();
            house.StreetId = street.Id;

            Console.Write("Amount per hour: ");
            TypeConverter decConv = TypeDescriptor.GetConverter(typeof(decimal));
            decimal amount = 0;

            _toContinue = true;
            while(_toContinue)
            {
                string amountString = Console.ReadLine();
                if (decConv.IsValid(amountString))
                {
                    amount = Convert.ToDecimal(amountString);
                    _toContinue = false;
                    break;
                }
                else
                    continue;
            }

            Console.Write("Square: ");

            _toContinue = true;
            TypeConverter intConv = TypeDescriptor.GetConverter(typeof(int));
            int square = 0;
            while (_toContinue)
            {
                string squareString = Console.ReadLine();
                if (intConv.IsValid(squareString))
                {
                    square = Convert.ToInt32(squareString);
                    _toContinue = false;
                    break;
                }
                else
                    continue;
            }

            Console.WriteLine("Description: ");
            string description = Console.ReadLine();

            try
            {
                AddAddress(city, street, house);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Can;t save city: {ex.Message}");
            }

            Space space = new Space();
            space.TypeOfSpaceId = typeOfSpace;
            space.HouseId = house.Id;
            space.AmountPerHour = amount;
            space.Square = square;
            space.Description = description;
            space.StatusId = 1;

            try
            {
                SQLConnection.AddSpace(space);

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Can't save space: {ex.Message}");
            }
            Console.WriteLine();
            Console.WriteLine("Excelent!");
            Console.WriteLine();
        }
    }
}
