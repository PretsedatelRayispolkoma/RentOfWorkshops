using RentOfWorkshopAPI.Models;
using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace RentOfWorkshopAPI.Services
{
    public static class ClientService
    {
        private static List<ClientModel> _clientsList;

        static ClientService()
        {
            _clientsList = new List<ClientModel>();
            foreach (var client in SQLConnection.GetAllClients())
                _clientsList.Add(new ClientModel
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    BirthDate = client.BirthDate,
                    Email = client.Email,
                    PhoneNumber = client.PhoneNumber
                });
        }

        public static List<ClientModel> ClientsList => _clientsList;

        public static ClientModel GetClient(int id) => _clientsList.Where(p => p.Id == id).FirstOrDefault();

        public static void Add(Client client)
        {
            SQLConnection.AddClient(client);
        }

        public static void Delete(int id)
        {
            var client = GetClient(id);
            if (client == null)
                return;

            SQLConnection.DeleteClient(id);
        }

        public static void Update(int id, Client client)
        {
            SQLConnection.Update(id, client);
        }
    }
}
