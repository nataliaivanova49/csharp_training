using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string format = args[2];
            string datatype = args[3];
            StreamWriter writer = new StreamWriter(args[1]);
            List<GroupData> groups = new List<GroupData>();
            List<AddressData> address = new List<AddressData>();
            if (datatype == "group")
            {
                for (int i = 0; i < count; i++)

                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognazied format" + format);
                }
                writer.Close();
            }
            else if (datatype == "address")
            {
                address.Add(new AddressData(TestBase.GenerateRandomString(30), TestBase.GenerateRandomString(30))
                {
                    Middlename = TestBase.GenerateRandomString(30),
                    Nickname = TestBase.GenerateRandomString(30),
                    Title = TestBase.GenerateRandomString(30),
                    Address = TestBase.GenerateRandomString(30),
                    Company = TestBase.GenerateRandomString(30),
                    Home = TestBase.GenerateRandomInt(11),
                    Mobile = TestBase.GenerateRandomInt(11),
                    Work = TestBase.GenerateRandomInt(11),
                    Fax = TestBase.GenerateRandomInt(11),
                    Email = TestBase.GenerateRandomString(20) + "@gmail.com",
                    Email2 = TestBase.GenerateRandomString(20) + "@mail.ru",
                    Email3 = TestBase.GenerateRandomString(20) + "@yandex.ru",
                    Homepage = "qqq.com",
                    Bday = "17",
                    Bmonth = "June",
                    Byear = "1985",
                    Aday = "17",
                    Amonth = "June",
                    Ayear = "2025",
                    Groupselection = "none",
                    Address2 = TestBase.GenerateRandomString(30),
                    Phone2 = TestBase.GenerateRandomInt(11),
                    Notes = TestBase.GenerateRandomString(100)
                });
                if (format == "xml")
                {
                    writeAddressToXmlFile(address, writer);
                }
                else if (format == "json")
                {
                    writeAddressToJsonFile(address, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognazied format" + format);
                }
                writer.Close();
            }

            else
            {
                System.Console.Out.Write("Unrecognazied type of data" + datatype);
            }
        }
        public static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer) 
        {
            foreach (GroupData group in groups) 
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer) 
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void writeAddressToXmlFile(List<AddressData> address, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<AddressData>)).Serialize(writer, address);
        }
        static void writeAddressToJsonFile(List<AddressData> address, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(address, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
