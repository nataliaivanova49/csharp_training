using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressModificationTests : AuthTestBase
    {
        [Test]
        public void AddressModificationTest()
        {
            AddressData newData = new AddressData("aaa","bbb");
            newData.Middlename = "qqq";
            newData.Nickname = "qqq";
            newData.Title = "qqq";
            newData.Company = "qqq";
            newData.Mobile = "+111";
            newData.Work = "111";
            newData.Fax = "111";
            newData.Email2 = "1119@gmail.com";
            newData.Email3 = "1119@gmail.com";
            newData.Homepage = "111.com";
            newData.Bday = "11";
            newData.Bmonth = "June";
            newData.Byear = null;
            newData.Aday = "11";
            newData.Amonth = "June";
            newData.Ayear = null;
            newData.Address2 = null;
            newData.Phone2 = null;
            newData.Notes = null;

            AddressData address = new AddressData("Natalia", "Ivanova");
            address.Middlename = "Alexander";
            address.Nickname = "nataliaivanova49";
            address.Title = "Test";
            address.Company = "ABC";
            address.Mobile = "+79041234567";
            address.Work = "88127654321";
            address.Fax = "88121726354";
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
            address.Phone2 = "++79999999999";
            address.Notes = "Notes";

            app.Address.RemoveModifyAddressPreparation(address);
            List<AddressData> oldAddress = app.Address.GetAddressList();
            app.Address.Modify(newData);
            List<AddressData> newAddress = app.Address.GetAddressList();
            oldAddress[0].Firstname = newData.Firstname;
            oldAddress[0].Lastname = newData.Lastname;
            oldAddress.Sort();
            newAddress.Sort();
            Assert.AreEqual(oldAddress, newAddress);
        }
    }
}
