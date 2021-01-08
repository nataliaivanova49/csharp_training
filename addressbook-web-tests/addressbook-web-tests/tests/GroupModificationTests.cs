using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("zzz");
            group.Header = "qwel";
            group.Footer = "tyuty";
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.RemoveModifyGroupPreparation(0, group);

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData item in newGroups)
            {
                if (item.Id == oldData.Id)
                {
                    Assert.AreEqual(item.Name, newData.Name);
                }
            }
        }
    }
}