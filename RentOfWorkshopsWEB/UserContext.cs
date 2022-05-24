using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
using System;
using System.Linq;

namespace RentOfWorkshopsWEB
{
    public class UserContext
    {
        internal User User { get; set; }

        internal bool HasRent { get; set; }

        public UserContext()
        {
            User = SQLConnection.GetGuest();
        }

        internal void SignOut()
        {
            User = SQLConnection.GetGuest();
        }
    }
}
