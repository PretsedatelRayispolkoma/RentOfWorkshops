using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOfWorkshopsTest
{
    [TestClass]
    internal class SQLConnectionTest
    {
        [TestMethod]
        public void GetSpaceTest()
        {
            Space space = SQLConnection.GetAllSpaces().Where(p => p.Id == 3).FirstOrDefault();
            Assert.AreEqual(space, SQLConnection.GetSpace(3));
        }
    }
}
