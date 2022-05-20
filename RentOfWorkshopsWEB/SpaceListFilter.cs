using System;

namespace RentOfWorkshopsWEB
{
    public class SpaceListFilter
    {
        private int _typeOfSpaceId = 2;

        public int TypeOfSpaceId
        {
            get => _typeOfSpaceId;
            set
            {
                _typeOfSpaceId = value;
            }
        }
    }
}
