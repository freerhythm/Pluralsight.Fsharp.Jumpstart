using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module6.ObjectOrientedTypes;

namespace Module6.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var expected = "Max Kritzinger";
            var me = new PersonFromInterface("Max", "Kritzinger");

            var mePerson = me as IPerson;

            Assert.AreEqual(expected, mePerson.Fullname);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var expectedCode = "01277";
            var expectedNumber = "345678";
            var contactDetails = Contact.NewPhoneNumber(expectedCode, expectedNumber);
            var me = new ContactPerson("Max", "Kritzinger", contactDetails);
            var prefContact = me.PreferredContact as Contact.PhoneNumber;
            var actualCode = prefContact.AreaCode;
            var actualNumber = prefContact.Number;

            Assert.AreEqual(expectedCode, prefContact.AreaCode);
            Assert.AreEqual(expectedNumber, prefContact.Number);
        }
    }
}
