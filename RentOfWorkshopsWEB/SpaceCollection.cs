using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentOfWorkshopsWEB
{
    internal class SpaceCollection
    {
        private List<Space> _spaceList = new List<Space>();

        internal List<Space> SpaceList 
        {
            get
            {
                return _spaceList;
            }
        }

        internal int TypeOfSpaceId { get; set; }

        internal string SearchString { get; set; }

        internal City City { get; set; }

        internal ValueTask UpdateList()
        {
            _spaceList = SQLConnection.GetAllSpaces();

            var typeOfSpace = SQLConnection.GetAllTypesOfSpace().Where(s => s.Id == TypeOfSpaceId).FirstOrDefault();

            if (typeOfSpace != null)
                _spaceList = SQLConnection.GetAllSpaces().Where(s => s.TypeOfSpaceId == TypeOfSpaceId).ToList();

            if (!String.IsNullOrEmpty(SearchString))
                _spaceList = _spaceList.Where(p => p.House.Street.Name.ToLower().Contains(SearchString.ToLower())).ToList();

            if (City != null)
                _spaceList = _spaceList.Where(p => p.House.Street.City.Id == City.Id).ToList();

            StateChanged?.Invoke(_spaceList);

            return new ValueTask();
        }

        internal event Action<List<Space>> StateChanged;
    }
}
