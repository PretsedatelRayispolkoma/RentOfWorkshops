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
        public static RentOfWorkshopsEntities RentDB = new RentOfWorkshopsEntities();

        public static List<User> GetAllUsers()
        {
            return new List<User>(RentDB.User);
        }

        public static List<Space> GetAllSpaces()
        {
            return new List<Space>(RentDB.Space);
        }


    }
}
