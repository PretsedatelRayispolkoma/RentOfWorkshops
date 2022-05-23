using RentOfWorkshopAPI.Models;
using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace RentOfWorkshopAPI.Services
{
    public static class SpaceService
    {
        private static List<SpaceModel> _spacesList;

        static SpaceService()
        {
            _spacesList = new List<SpaceModel>();
            foreach (var space in SQLConnection.GetAllSpaces())
                _spacesList.Add(new SpaceModel
                {
                    Id = space.Id,
                    TypeOfSpaceName = space.TypeOfSpace.Name,
                    AmountPerHour = space.AmountPerHour,
                    Description = space.Description,
                    Square = space.Square,
                    Address = space.House.Street.City.Name + ", " + space.House.Street.Name +
                    ", " + space.House.Number,
                    StatusId = space.Status.Name
                });  
        }

        public static List<SpaceModel> SpaceList => _spacesList;

        public static SpaceModel GetSpace(int id) => _spacesList.Where(p => p.Id == id).FirstOrDefault();

        public static void Add(Space space)
        {
            SQLConnection.AddSpace(space);
        }

        public static void Delete(int id)
        {
            var space = GetSpace(id);
            if (space == null)
                return;

            SQLConnection.DeleteSpace(id);
        }

        public static void Update(int id, Space space)
        {
            SQLConnection.Update(id, space);
        }
    }
}
