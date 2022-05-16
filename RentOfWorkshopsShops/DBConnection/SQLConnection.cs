using RentOfWorkshopsCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOfWorkshopsCore.DBConnection
{
    public class SQLConnection
    {
        private static RentOfWorkshopsEntities RentDB = new RentOfWorkshopsEntities();

        public static List<User> GetAllUsers()
        {
            return new List<User>(RentDB.User);
        }

        public static List<Space> GetAllSpaces()
        {
            return new List<Space>(RentDB.Space);
        }

        public static Space AttachSpace(Space space)
        {
            return RentDB.Space.Attach(space);
        }

        public static void Save()
        {
            RentDB.SaveChanges();
        }
    }
}
