using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class AddressRemovalTests : TestBase
    {
        [Test]
        public void AddressRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Address.SelectAddress(1);
            app.Address.RemoveAddress(true);
            app.Navigator.GoToHomePage();
            app.Logout.Logout();
        }

    }
}
