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

        public SpaceCollection()
        {
            UpdateList();
        }

        internal bool ShowAll { get; set; } = false;

        internal int OrderBy { get; set; } = 1;

        internal int TypeOfSpaceId { get; set; } = 2;

        internal string SearchString { get; set; }

        internal City City { get; set; }

        internal ValueTask UpdateList()
        {
            _spaceList = SQLConnection.GetAllSpaces().ToList();

            var typeOfSpace = SQLConnection.GetAllTypesOfSpace().Where(s => s.Id == TypeOfSpaceId).FirstOrDefault();

            if (typeOfSpace != null)
                _spaceList = SQLConnection.GetAllSpaces().Where(s => s.TypeOfSpaceId == TypeOfSpaceId).ToList();

            if (!String.IsNullOrEmpty(SearchString))
                _spaceList = _spaceList.Where(p => p.House.Street.Name.ToLower().Contains(SearchString.ToLower())).ToList();

            if (City != null)
                _spaceList = _spaceList.Where(p => p.House.Street.City.Id == City.Id).ToList();
            
            switch(OrderBy)
            {
                case 1:
                    _spaceList = _spaceList.OrderBy(p => p.Id).ToList();
                    break;
                case 2:
                    _spaceList = _spaceList.OrderBy(p => p.AmountPerHour).ToList();
                    break;
                case 3:
                    _spaceList = _spaceList.OrderByDescending(p => p.AmountPerHour).ToList();
                    break;
                default:
                    _spaceList = _spaceList.OrderBy(p => p.Id).ToList();
                    break;
            }

            _spaceList = _spaceList.Where(p => p.StatusId == 1 && p.IsDeleted == false).ToList();

            StateChanged?.Invoke(_spaceList);

            return new ValueTask();
        }

        internal event Action<List<Space>> StateChanged;
    }
}
