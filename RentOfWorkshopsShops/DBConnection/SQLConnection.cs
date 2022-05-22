using RentOfWorkshopsCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOfWorkshopsCore.DBConnection
{
    public class SQLConnection
    {
        private static RentOfWorkshopsEntities RentDB = new RentOfWorkshopsEntities();

        public static List<User> GetAllUsers()
        {
            return new List<User>(RentDB.User);
        }

        public static List<Space> GetAllSpaces()
        {
            return new List<Space>(RentDB.Space);
        }

        public static List<TypeOfSpace> GetAllTypesOfSpace()
        {
            return RentDB.TypeOfSpace.ToList();
        }

        public static List<City> GetAllCities()
        {
            return RentDB.City.ToList();
        }

        public static List<Status> GetStatuses()
        {
            return RentDB.Status.ToList();
        }

        public static Space AttachSpace(Space space)
        {
            return RentDB.Space.Attach(space);
        }

        public static User GetRole(string login, string password)
        {
            foreach (var authUser in RentDB.User)
            {
                if (authUser.Login == login.Trim())
                {
                    if (authUser.Password == password.Trim())
                    {
                        return authUser;
                    }
                    else continue;
                }
            }
            return null;
        }

        public static User GetGuest()
        {
            return RentDB.User.Where(p => p.RoleId == 3).FirstOrDefault();
        }

        public static void Registrate(string fName, string lName, string bDate, 
            string number, string email, string login, string password, string repeatPassword)
        {
            Client client = new Client();
        }

        public static void Save()
        {
            RentDB.SaveChanges();
        }

        public static Space GetSpace(int id)
        {
            return RentDB.Space.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
