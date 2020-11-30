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
            app.Address.Remove(1);                               
        }

    }
}
