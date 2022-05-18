using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;

namespace RentOfWorkshopsWEB
{
    public class UserContext
    {
        public User User { get; set; }

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
