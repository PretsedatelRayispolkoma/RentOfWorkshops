using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
using System;
using System.Linq;

namespace RentOfWorkshopsWEB
{
    public class UserContext
    {
        public User User { get; set; }

        public bool HasRent { get; set; }

        public UserContext()
        {
            User = SQLConnection.GetGuest();
        }

        public void SignOut()
        {
            User = SQLConnection.GetGuest();
        }
    }
}
