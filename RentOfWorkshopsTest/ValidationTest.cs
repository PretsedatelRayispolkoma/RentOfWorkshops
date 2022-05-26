using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentOfWorkshopsCore.DBContext;
using RentOfWorkshopsCore.DBConnection;
using System.Linq;
using RentOfWorkshopsCore.Validation;
using System;

namespace RentOfWorkshopsTest
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void StringValidationTest()
        {
            Assert.ThrowsException<InvalidOperationException>(() => Validation.StringValidation("123@#!#"));
        }

        [TestMethod]
        public void DateTimeValidationTest()
        {
            Assert.ThrowsException<InvalidOperationException>(() => Validation.DateValidation(DateTime.Now));
        }

        [TestMethod]
        public void PhoneValidationTest()
        {
            Assert.ThrowsException<InvalidOperationException>(() => Validation.PhoneValidation("7087047456"));
        }
    }
}
