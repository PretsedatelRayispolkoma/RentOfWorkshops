using System;
using RentOfWorkShopsConsoleApp.ProjectService;
using RentOfWorkshopsCore.DBConnection;

namespace RentOfWorkShopsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthRequest.Authorization();

            Console.WriteLine("Requests to data base:\n" +
                "add_space \nget_spaces");
            while(true)
            {
                string request = Console.ReadLine();
                SpaceRequest.AnswerRequest(request);
            }
        }
    }
}
