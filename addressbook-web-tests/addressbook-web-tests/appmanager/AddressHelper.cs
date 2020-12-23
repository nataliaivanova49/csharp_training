using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebAddressbookTests
{
    public class AddressHelper : HelperBase
    {

        public AddressHelper(ApplicationManager manager) : base(manager) { }

        public AddressData GetAddressInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allMails = cells[4].Text;

            return new AddressData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllMails = allMails 
            };
        }

        public AddressData GetAddressInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitAddressModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string homePhone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            return new AddressData(firstName, lastName)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Phone2 = homePhone2,
                Email = email,
                Email2 = email2,
                Email3 = email3
                       
            };
        }

        public AddressHelper Create(AddressData address)
        {
            InitNewAddressCreation();
            FillAddressForm(address);
            SubmitAddressCreation();
            return this;
        }
        public AddressHelper Modify(AddressData newData)
        {
            InitAddressModification(0);
            FillModifiedAddressForm(newData);
            SubmitAddressModification();
            return this;
        }

        public AddressHelper FillModifiedAddressForm(AddressData newData)
        {
            {
                Type(By.Name("firstname"), newData.Firstname);
                Type(By.Name("middlename"), newData.Middlename);
                Type(By.Name("lastname"), newData.Lastname);
                Type(By.Name("nickname"), newData.Nickname);
                PhotoUpload();
                Type(By.Name("title"), newData.Title);
                Type(By.Name("company"), newData.Company);
                Type(By.Name("address"), newData.Address);
                Type(By.Name("home"), newData.Home);
                Type(By.Name("mobile"), newData.Mobile);
                Type(By.Name("work"), newData.Work);
                Type(By.Name("fax"), newData.Fax);
                Type(By.Name("email"), newData.Email);
                Type(By.Name("email2"), newData.Email2);
                Type(By.Name("email3"), newData.Email3);
                Type(By.Name("homepage"), newData.Homepage);
                new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(newData.Bday);
                driver.FindElement(By.XPath("//option[@value='17']")).Click();
                new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("June");
                driver.FindElement(By.XPath("//option[@value='June']")).Click();
                Type(By.Name("byear"), newData.Byear);
                new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(newData.Aday);
                driver.FindElement(By.XPath("(//option[@value='17'])[2]")).Click();
                new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("June");
                driver.FindElement(By.XPath("(//option[@value='June'])[2]")).Click();
                Type(By.Name("ayear"), newData.Ayear);
                Type(By.Name("address2"), newData.Address2);
                Type(By.Name("phone2"), newData.Phone2);
                Type(By.Name("notes"), newData.Notes);
                return this;
            }
        }

        public AddressHelper Remove(int q)
        {            
            SelectAddress(q);
            RemoveAddress();
            return this;
        }

        private List<AddressData> addressCache = null;
        public List<AddressData> GetAddressList()
        {
            if (addressCache == null)
            {
                addressCache = new List<AddressData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
                foreach (IWebElement element in elements)
                {
                    var cells = element.FindElements(By.TagName("td"));
                    if (cells.Count > 3)
                    {
                        var surname = cells[1].Text;
                        var name = cells[2].Text;
                        addressCache.Add(new AddressData(name, surname));
                    }
                }
               
            }
            return new List<AddressData>(addressCache);
        }
        public AddressHelper SubmitAddressCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            addressCache = null;
            return this;
        }

        public AddressHelper FillAddressForm(AddressData address)
        {
            Type(By.Name("firstname"), address.Firstname);
            Type(By.Name("middlename"), address.Middlename);
            Type(By.Name("lastname"), address.Lastname);
            Type(By.Name("nickname"), address.Nickname);
            PhotoUpload();
            Type(By.Name("title"), address.Title);
            Type(By.Name("company"), address.Company);
            Type(By.Name("address"), address.Address);
            Type(By.Name("home"), address.Home);
            Type(By.Name("mobile"), address.Mobile);
            Type(By.Name("work"), address.Work);
            Type(By.Name("fax"), address.Fax);
            Type(By.Name("email"), address.Email);
            Type(By.Name("email2"), address.Email2);
            Type(By.Name("email3"), address.Email3);
            Type(By.Name("homepage"), address.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(address.Bday);
            driver.FindElement(By.XPath("//option[@value='17']")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("June");
            driver.FindElement(By.XPath("//option[@value='June']")).Click();
            Type(By.Name("byear"), address.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(address.Aday);
            driver.FindElement(By.XPath("(//option[@value='17'])[2]")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("June");
            driver.FindElement(By.XPath("(//option[@value='June'])[2]")).Click();
            Type(By.Name("ayear"), address.Ayear);
            // SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("aaa");
            //driver.FindElement(By.XPath("(//option[@value='15'])[3]")).Click();
            Type(By.Name("address2"), address.Address2);
            Type(By.Name("phone2"), address.Phone2);
            Type(By.Name("notes"), address.Notes);
            return this;
        }



        public void PhotoUpload()
        {
            By fileInput = By.CssSelector("input[type=file]");
            String filePath = "C:\\Selenium\\Addressbook.png";
            driver.FindElement(fileInput).SendKeys(filePath);
        }
        public AddressHelper InitNewAddressCreation()
        {
            driver.FindElement(By.Id("content")).Click();
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public AddressHelper SelectAddress(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public AddressHelper RemoveAddress()
        {
           
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.ClassName("msgbox"));            
            addressCache = null;
            return this;
        }
        public AddressHelper SubmitAddressModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            addressCache = null;
            return this;
        }

        public void InitAddressModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();           
        }
        public bool IsAddressPresent()
        {
            try
            {
                driver.FindElement(By.XPath("//img[@alt='Edit']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public AddressHelper RemoveModifyAddressPreparation(AddressData address)
        {
            if (!IsAddressPresent())
            {
                Create(address);
                manager.Navigator.GoToHomePage();
            }
            return this;
        }
        
    }
}


