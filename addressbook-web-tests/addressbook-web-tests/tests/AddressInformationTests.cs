﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressInformationTests : AuthTestBase
    {
        [Test]
        public void TestAddressInformation() 
        {
            AddressData fromTable = app.Address.GetAddressInformationFromTable(0);
            AddressData fromForm = app.Address.GetAddressInformationFromEditForm(0);
            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllMails, fromForm.AllMails);
        }
    }
}