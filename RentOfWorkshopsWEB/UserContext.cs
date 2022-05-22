using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;

namespace RentOfWorkshopsWEB
{
    public class UserContext
    {
        internal User User { get; set; }

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
