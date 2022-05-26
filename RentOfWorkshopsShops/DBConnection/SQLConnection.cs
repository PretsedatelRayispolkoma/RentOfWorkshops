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

        public static List<Client> GetAllClients()
        {
            return RentDB.Client.ToList();
        }

        public static Space GetSpace(int id)
        {
            return RentDB.Space.Where(p => p.Id == id).FirstOrDefault();
        }

        public static void AddSpace(Space space)
        {
            RentDB.Space.Add(space);
            RentDB.SaveChanges();
        }

        public static List<Street> GetStreet(int cityId)
        {
            return RentDB.Street.Where(p => p.CityId == cityId).ToList();
        }

        public static List<House> GetHouses(int streetId)
        {
            return RentDB.House.Where(p => p.StreetId == streetId).ToList();
        }

        public static void DeleteSpace(int id)
        {
            var currentSpace = RentDB.Space.Where(p => p.Id == id).FirstOrDefault();
            RentDB.Space.Attach(currentSpace);
            currentSpace.IsDeleted = true;
            RentDB.SaveChanges();
        }

        public static void Update(int id, Space space)
        {
            var newSpace = RentDB.Space.FirstOrDefault(p => p.Id == id);
            newSpace = space;
            RentDB.SaveChanges();
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

        public static void AddClient(Client client)
        {
            RentDB.Client.Add(client);
            RentDB.SaveChanges();
        }

        public static void DeleteClient(int id)
        {
            var currentClient = RentDB.Client.Where(p => p.Id == id).FirstOrDefault();
            RentDB.Client.Remove(currentClient);
            RentDB.SaveChanges();
        }

        public static void Update(int id, Client client)
        {
            var newClient = RentDB.Client.FirstOrDefault<Client>(p => p.Id == id);
            newClient = client;
            RentDB.SaveChanges();
        }

        public static void AddUser(User user)
        {
            RentDB.User.Add(user);
            RentDB.SaveChanges();

        }

        public static Client AttachClient(Client client)
        {
            return RentDB.Client.Attach(client);
        }

        public static void AddAddress(City city, Street street, House house)
        {
            RentDB.City.Add(city);
            RentDB.Street.Add(street);
            RentDB.House.Add(house);
            RentDB.SaveChanges();
        }

        public static List<Rent> GetRents(int clientId)
        {
            return RentDB.Rent.Where(p => p.ClientId == clientId).ToList();
        }

        public static void AddRent(Rent rent)
        {
            RentDB.Rent.Add(rent);
            RentDB.SaveChanges();
        }
    }
}
