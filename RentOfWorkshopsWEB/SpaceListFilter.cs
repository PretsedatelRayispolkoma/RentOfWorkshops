using System;

namespace RentOfWorkshopsWEB
{
    public class SpaceListFilter
    {
        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                DivisionSelected?.Invoke();
            }
        }
        public event Action DivisionSelected;
    }
}
