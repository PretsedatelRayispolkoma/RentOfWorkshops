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
                    TypeOfSpaceId = space.TypeOfSpaceId,
                    AmountPerHour = space.AmountPerHour,
                    Description = space.Description,
                    Square = space.Square,
                    HouseId = space.HouseId,
                    Picture = space.Picture,
                    StatusId = space.StatusId
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
    }
}
