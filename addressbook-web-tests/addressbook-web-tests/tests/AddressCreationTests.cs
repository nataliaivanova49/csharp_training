using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressCreationTests : AddressTestBase
    {
        public static IEnumerable<AddressData> RandomAddressDataProvider()
        {
            List<AddressData> address = new List<AddressData>();
            for (int i = 0; i < 5; i++)
            {
                address.Add(new AddressData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(30),
                    Nickname = GenerateRandomString(30),
                    Title = GenerateRandomString(30),
                    Address = GenerateRandomString(30),
                    Company = GenerateRandomString(30),
                    Home = GenerateRandomInt(11),
                    Mobile = GenerateRandomInt(11),
                    Work = GenerateRandomInt(11),
                    Fax = GenerateRandomInt(11),
                    Email = GenerateRandomString(20) + "@gmail.com",
                    Email2 = GenerateRandomString(20) + "@mail.ru",
                    Email3 = GenerateRandomString(20) + "@yandex.ru",
                    Homepage = "qqq.com",
                    Bday = "17",
                    Bmonth = "June",
                    Byear = "1985",
                    Aday = "17",
                    Amonth = "June",
                    Ayear = "2025",
                    Groupselection = "none",
                    Address2 = GenerateRandomString(30),
                    Phone2 = GenerateRandomInt(11),
                    Notes = GenerateRandomString(100)
                });
            };
           
            return address;
        }
        public static IEnumerable<AddressData> AddressDataFromXmlFile()
        {
            List<AddressData> address = new List<AddressData>();
            return (List<AddressData>)
                new XmlSerializer(typeof(List<AddressData>))
                   .Deserialize(new StreamReader(@"address.xml"));
        }
        public static IEnumerable<AddressData> AddressDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<AddressData>>(File.ReadAllText(@"address.json"));

        }
        [Test, TestCaseSource("RandomAddressDataProvider")]
        public void AddressCreationTest(AddressData address)
        {            
            List<AddressData> oldAddress = AddressData.GetAll();
            app.Address.Create(address);
            List<AddressData> newAddress = AddressData.GetAll();
            oldAddress.Add(address);
            oldAddress.Sort();
            newAddress.Sort();
            Assert.AreEqual(oldAddress, newAddress);
           
        }
       
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<AddressData> fromUi = app.Address.GetAddressList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<AddressData> fromDb = AddressData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

        }
    }
}
