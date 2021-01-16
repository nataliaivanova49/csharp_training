using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressRemovalTests : AddressTestBase
    {
        [Test]
        public void AddressRemovalTest() 
        {
            
            AddressData address = new AddressData("Natalia", "Ivanova")
            {
                Middlename = "Alexander",
                Nickname = "nataliaivanova49",
                Title = "Test",
                Company = "ABC",
                Mobile = "+79041234567",
                Work = "88127654321",
                Fax = "88121726354",
                Email2 = "nataliaivanova49@gmail.com",
                Email3 = "nataliaivanova49@gmail.com",
                Homepage = "qqq.com",
                Bday = "17",
                Bmonth = "June",
                Byear = "1985",
                Aday = "17",
                Amonth = "June",
                Ayear = "2025",
                Groupselection = "none",
                Address2 = "1234567 Address2",
                Phone2 = "+79999999999",
                Notes = "Notes"
            };
            app.Address.RemoveModifyAddressPreparation(address);

            List<AddressData> oldAddress = AddressData.GetAll();
            AddressData toBeRemoved = oldAddress[0];
            app.Address.Remove(toBeRemoved);
            
            List<AddressData> newAddress = AddressData.GetAll();
            oldAddress.RemoveAt(0);
            Assert.AreEqual(oldAddress, newAddress);
        }

    }
}
