using RentOfWorkshopsCore.DBContext;

namespace RentOfWorkshopsWEB
{
    public class UserContext
    {
        public User User { get; set; }

        public UserContext()
        {
            User = new User();
        }
    }
}
