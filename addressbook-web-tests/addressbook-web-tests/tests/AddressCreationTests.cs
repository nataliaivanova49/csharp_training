﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressCreationTests : TestBase
    {
        [Test]
        public void AddressCreationTest()
        {
            AddressData address = new AddressData("Natalia", "Ivanova", "123456 Address", "88121234567", "nataliaivanova49@gmail.com");
            address.Middlename = "Alexander";
            address.Nickname = "nataliaivanova49";
            address.Title = "Test";
            address.Company = "ABC";
            address.Mobile = "+79041234567";
            address.Work = "88127654321";
            address.Fax = "88121726354";
            address.Email2 = "nataliaivanova49@gmail.com";
            address.Email3 = "nataliaivanova49@gmail.com";
            address.Homepage = "qqq.com";
            address.Bday = "17";
            address.Bmonth = "June";
            address.Byear = "1985";
            address.Aday = "17";
            address.Amonth = "June";
            address.Ayear = "2025";
            address.Groupselection = "none";
            address.Address2 = "1234567 Address2";
            address.Phone2 = "++79999999999";
            address.Notes = "Notes";

            app.Address.Create(address);          
                      
        }
        [Test]
        public void EmptyAddressCreationTest()
        {
            AddressData address = new AddressData("", "", "", "", "");
            address.Middlename = "";
            address.Nickname = "";
            address.Title = "";
            address.Company = "";
            address.Mobile = "";
            address.Work = "";
            address.Fax = "";
            address.Email2 = "";
            address.Email3 = "";
            address.Homepage = "";
            address.Bday = "";
            address.Bmonth = "";
            address.Byear = "";
            address.Aday = "";
            address.Amonth = "";
            address.Ayear = "";
            address.Groupselection = "none";
            address.Address2 = "";
            address.Phone2 = "";
            address.Notes = "";

            app.Address.Create(address);

        }

    }
}
