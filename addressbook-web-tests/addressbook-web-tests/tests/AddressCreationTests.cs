using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressCreationTests : AuthTestBase
    {
        [Test]
        public void AddressCreationTest()
        {
            AddressData address = new AddressData("Natalia", "Ivanova");
            address.Middlename = "Alexander";
            address.Nickname = "nataliaivanova49";
            address.Title = "Test";
            address.Address = "123456 Address";
            address.Company = "ABC";
            address.Home = "88121234567";
            address.Mobile = "+79041234567";
            address.Work = "88127654321";
            address.Fax = "88121726354";
            address.Email = "nataliaivanova49@gmail.com";
            address.Email2 = "nataliaivanova49@gmail.com";
            address.Email3 = "nataliaivanova49@gmail.com";
            address.Homepage = "qqq.com";
            address.Bday = "17";
            address.Bmonth = "June";
            address.Byear = "1985";
            address.Aday = "17";
            address.Amonth = "June";
            address.Ayear = "2025";
            address.Groupselection = "none";
            address.Address2 = "1234567 Address2";
            address.Phone2 = "+79999999999";
            address.Notes = "Notes";
            
            List<AddressData> oldAddress = app.Address.GetAddressList();
            app.Address.Create(address);
            List<AddressData> newAddress = app.Address.GetAddressList();
            oldAddress.Add(address);
            oldAddress.Sort();
            newAddress.Sort();
            Assert.AreEqual(oldAddress, newAddress);
           
        }
        [Test]
        public void EmptyAddressCreationTest()
        {
            AddressData address = new AddressData("", "");
            address.Middlename = "";
            address.Nickname = "";
            address.Title = "";
            address.Address = "";
            address.Home = "";
            address.Company = "";
            address.Mobile = "";
            address.Work = "";
            address.Fax = "";
            address.Email = "";
            address.Email2 = "";
            address.Email3 = "";
            address.Homepage = "";
            address.Bday = "";
            address.Bmonth = "";
            address.Byear = "";
            address.Aday = "";
            address.Amonth = "";
            address.Ayear = "";
            address.Groupselection = "none";
            address.Address2 = "";
            address.Phone2 = "";
            address.Notes = "";

            List<AddressData> oldAddress = app.Address.GetAddressList();
            app.Address.Create(address);
            List<AddressData> newAddress = app.Address.GetAddressList();
            oldAddress.Add(address);
            oldAddress.Sort();
            newAddress.Sort();
            Assert.AreEqual(oldAddress, newAddress);
        }

    }
}
