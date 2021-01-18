using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
    public class RemovingAddressFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingAddressFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<AddressData> oldList = group.GetAddress();
            AddressData address = oldList.First();

            //actions
            app.Address.RemoveAddressFromGroup(address, group);

            List<AddressData> newList = group.GetAddress();
            oldList.Remove(address);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
