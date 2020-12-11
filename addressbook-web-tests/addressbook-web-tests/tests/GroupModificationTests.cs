﻿using System;
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
            app.Groups.RemoveModifyGroupPreparation(1, group);
            app.Groups.Modify(1, newData);
        }
    }
}