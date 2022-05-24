using RentOfWorkshopsCore.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOfWorkShopsConsoleApp.ProjectService
{
    internal static class AuthRequest
    {
        public static void Authorization()
        {
            Console.WriteLine("Authorization: ");
            bool _isntValid = true;
            while(_isntValid)
            {
                Console.Write("Login: ");
                string login = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                var user = SQLConnection.GetRole(login, password);

                if (user == null)
                {
                    Console.WriteLine("User not found");
                    continue;
                }
                else
                {
                    _isntValid = false;
                }
            }
        }
    }
}
