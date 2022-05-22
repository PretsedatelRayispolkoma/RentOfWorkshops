using RentOfWorkshopsCore.DBContext;
using System;
using System.Collections.Generic;

namespace RentOfWorkshopsWEB
{
    internal class SpaceListFilter
    { 
        private int _typeOfSpaceId = 2;

        internal int TypeOfSpaceId
        {
            get => _typeOfSpaceId;
            set
            {
                _typeOfSpaceId = value;
            }
        }

        internal City City { get; set; } 
    }
}
