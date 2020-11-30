using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressModificationTests : TestBase
    {
        [Test]
        public void AddressModificationTest()
        {
            AddressData newData = new AddressData("aaa","bbb","ccc","ddd", "eee");
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
            newData.Byear = "1985";
            newData.Aday = "11";
            newData.Amonth = "June";
            newData.Ayear = "2025";
            newData.Address2 = "111";
            newData.Phone2 = "+111";
            newData.Notes = "222";

            app.Address.Modify(newData);
        }
    }
}
