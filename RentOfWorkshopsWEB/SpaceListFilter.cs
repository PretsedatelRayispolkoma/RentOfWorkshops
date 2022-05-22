using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentOfWorkshopsWEB
{
    internal class SpaceListFilter
    { 
        private int _typeOfSpaceId = 2;

        private string _searchString;

        internal string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
            }
        }

        internal int TypeOfSpaceId
        {
            get => _typeOfSpaceId;
            set
            {
                _typeOfSpaceId = value;
            }
        }

        internal City City { get; set; }

        internal ValueTask<List<Space>> UpdateList(List<Space> spaceList)
        {
            spaceList = SQLConnection.GetAllSpaces();

            var typeOfSpace = SQLConnection.GetAllTypesOfSpace().Where(s => s.Id == TypeOfSpaceId).FirstOrDefault();

            if (typeOfSpace != null)
                spaceList = SQLConnection.GetAllSpaces().Where(s => s.TypeOfSpaceId == TypeOfSpaceId).ToList();

            if (!String.IsNullOrEmpty(_searchString))
                spaceList = spaceList.Where(p => p.House.Street.Name.ToLower().Contains(_searchString.ToLower())).ToList();

            if (City != null)
                spaceList = spaceList.Where(p => p.House.Street.City.Id == City.Id).ToList();

            StateChanged?.Invoke();

            return new ValueTask<List<Space>>(spaceList);
        }

        internal event Action StateChanged;
    }
}
