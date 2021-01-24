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
            List<GroupData> allGroups = GroupData.GetAll();
            if (allGroups.Count == 0) 
            {
                GroupData groupToCreate = new GroupData("zzz");
                groupToCreate.Header = "rrr";
                groupToCreate.Footer = "ccc";

                app.Groups.Create(groupToCreate);
            }

            GroupData group = GroupData.GetAll()[0];
            List<AddressData> oldList = group.GetAddress();
            List<AddressData> allAddress = AddressData.GetAll();
            List<AddressData> addressNotInGroup = allAddress.FindAll(t => oldList.All(x => x.Id != t.Id));
            if (addressNotInGroup.Count == 0) 
            {
                AddressData addressToCreate = new AddressData("qqq", "rrr");
                addressToCreate.Middlename = "qqq";
                addressToCreate.Nickname = "qqq";
                addressToCreate.Title = "qqq";
                addressToCreate.Address = "qqq";
                addressToCreate.Company = "qqq";
                addressToCreate.Home = "qqq";
                addressToCreate.Mobile = "qqq";
                addressToCreate.Work = "qqq";
                addressToCreate.Fax = "qqq";
                addressToCreate.Email = "qqq" + "@gmail.com";
                addressToCreate.Email2 = "qqq" + "@mail.ru";
                addressToCreate.Email3 = "qqq" + "@yandex.ru";
                addressToCreate.Homepage = "qqq.com";
                addressToCreate.Bday = "17";
                addressToCreate.Bmonth = "June";
                addressToCreate.Byear = "1985";
                addressToCreate.Aday = "17";
                addressToCreate.Amonth = "June";
                addressToCreate.Ayear = "2025";
                addressToCreate.Groupselection = "none";
                addressToCreate.Address2 = "qqq";
                addressToCreate.Phone2 = "qqq";
                addressToCreate.Notes = "qqq";
                app.Address.Create(addressToCreate);
                addressNotInGroup.Add(addressToCreate);
            }

            AddressData address = addressNotInGroup.First();
            

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
