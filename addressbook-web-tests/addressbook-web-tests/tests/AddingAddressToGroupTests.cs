using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class AddingAddressToGroupTests : AuthTestBase 
    {
        [Test]
        public void TestAddingAddressToGroup() 
        {
            GroupData group = GroupData.GetAll()[0];
            List<AddressData> oldList = group.GetAddress();
            List<AddressData> allAddress = AddressData.GetAll();
            AddressData address = allAddress.First(t => oldList.All(x => x.Id != t.Id));
            

            //actions
            app.Address.AddAddressToGroup(address, group);

            List<AddressData> newList = group.GetAddress();
            oldList.Add(address);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    

    } 
}
