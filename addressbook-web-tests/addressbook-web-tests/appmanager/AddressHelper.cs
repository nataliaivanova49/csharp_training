using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class AddressHelper : HelperBase
    {

        public AddressHelper(ApplicationManager manager) : base(manager) { }
        public AddressHelper Create(AddressData address)
        {
            InitNewAddressCreation();
            FillAddressForm(address);
            SubmitAddressCreation();
            return this;
        }
        public AddressHelper Modify(AddressData newData)
        {
            InitAddressModofocation();
            FillModifiedAddressForm(newData);
            SubmitAddressModification();
            return this;
        }

        public AddressHelper FillModifiedAddressForm(AddressData newData)
        {
            {
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).Clear();
                driver.FindElement(By.Name("firstname")).SendKeys(newData.Firstname);
                driver.FindElement(By.Name("middlename")).Click();
                driver.FindElement(By.Name("middlename")).Clear();
                driver.FindElement(By.Name("middlename")).SendKeys(newData.Middlename);
                driver.FindElement(By.Name("lastname")).Click();
                driver.FindElement(By.Name("lastname")).Clear();
                driver.FindElement(By.Name("lastname")).SendKeys(newData.Lastname);
                driver.FindElement(By.Name("nickname")).Click();
                driver.FindElement(By.Name("nickname")).Clear();
                driver.FindElement(By.Name("nickname")).SendKeys(newData.Nickname);
                PhotoUpload();
                driver.FindElement(By.Name("title")).Click();
                driver.FindElement(By.Name("title")).Clear();
                driver.FindElement(By.Name("title")).SendKeys(newData.Title);
                driver.FindElement(By.Name("company")).Click();
                driver.FindElement(By.Name("company")).Clear();
                driver.FindElement(By.Name("company")).SendKeys(newData.Company);
                driver.FindElement(By.Name("address")).Click();
                driver.FindElement(By.Name("address")).Clear();
                driver.FindElement(By.Name("address")).SendKeys(newData.Address);
                driver.FindElement(By.Name("home")).Click();
                driver.FindElement(By.Name("home")).Clear();
                driver.FindElement(By.Name("home")).SendKeys(newData.Home);
                driver.FindElement(By.Name("mobile")).Click();
                driver.FindElement(By.Name("mobile")).Clear();
                driver.FindElement(By.Name("mobile")).SendKeys(newData.Mobile);
                driver.FindElement(By.Name("work")).Click();
                driver.FindElement(By.Name("work")).Clear();
                driver.FindElement(By.Name("work")).SendKeys(newData.Work);
                driver.FindElement(By.Name("fax")).Click();
                driver.FindElement(By.Name("fax")).Clear();
                driver.FindElement(By.Name("fax")).SendKeys(newData.Fax);
                driver.FindElement(By.Name("email")).Click();
                driver.FindElement(By.Name("email")).Clear();
                driver.FindElement(By.Name("email")).SendKeys(newData.Email);
                driver.FindElement(By.Name("email2")).Click();
                driver.FindElement(By.Name("email2")).Clear();
                driver.FindElement(By.Name("email2")).SendKeys(newData.Email2);
                driver.FindElement(By.Name("email3")).Click();
                driver.FindElement(By.Name("email3")).Clear();
                driver.FindElement(By.Name("email3")).SendKeys(newData.Email3);
                driver.FindElement(By.Name("homepage")).Click();
                driver.FindElement(By.Name("homepage")).Clear();
                driver.FindElement(By.Name("homepage")).SendKeys(newData.Homepage);
                driver.FindElement(By.Name("bday")).Click();
                new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(newData.Bday);
                driver.FindElement(By.XPath("//option[@value='17']")).Click();
                driver.FindElement(By.Name("bmonth")).Click();
                new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("June");
                driver.FindElement(By.XPath("//option[@value='June']")).Click();
                driver.FindElement(By.Name("byear")).Click();
                driver.FindElement(By.Name("byear")).Clear();
                driver.FindElement(By.Name("byear")).SendKeys(newData.Byear);
                driver.FindElement(By.Name("aday")).Click();
                new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(newData.Aday);
                driver.FindElement(By.XPath("(//option[@value='17'])[2]")).Click();
                driver.FindElement(By.Name("amonth")).Click();
                new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("June");
                driver.FindElement(By.XPath("(//option[@value='June'])[2]")).Click();
                driver.FindElement(By.Name("ayear")).Click();
                driver.FindElement(By.Name("ayear")).Clear();
                driver.FindElement(By.Name("ayear")).SendKeys(newData.Ayear);
                driver.FindElement(By.Name("address2")).Click();
                driver.FindElement(By.Name("address2")).Clear();
                driver.FindElement(By.Name("address2")).SendKeys(newData.Address2);
                driver.FindElement(By.Name("phone2")).Click();
                driver.FindElement(By.Name("phone2")).Clear();
                driver.FindElement(By.Name("phone2")).SendKeys(newData.Phone2);
                driver.FindElement(By.Name("notes")).Click();
                driver.FindElement(By.Name("notes")).Clear();
                driver.FindElement(By.Name("notes")).SendKeys(newData.Notes);
                return this;
            }
        }

        public AddressHelper Remove(int q)
        {
            SelectAddress(q);
            RemoveAddress();
            return this;
        }

        public AddressHelper SubmitAddressCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public AddressHelper FillAddressForm(AddressData address)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(address.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(address.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(address.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(address.Nickname);
            PhotoUpload();
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(address.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(address.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(address.Address);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(address.Home);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(address.Mobile);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(address.Work);
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(address.Fax);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(address.Email);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(address.Email2);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(address.Email3);
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(address.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(address.Bday);
            driver.FindElement(By.XPath("//option[@value='17']")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("June");
            driver.FindElement(By.XPath("//option[@value='June']")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(address.Byear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(address.Aday);
            driver.FindElement(By.XPath("(//option[@value='17'])[2]")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("June");
            driver.FindElement(By.XPath("(//option[@value='June'])[2]")).Click();
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(address.Ayear);
            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("aaa");
            driver.FindElement(By.XPath("(//option[@value='10'])[3]")).Click();
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(address.Address2);
            driver.FindElement(By.Name("phone2")).Click();
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(address.Phone2);
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(address.Notes);
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public AddressHelper RemoveAddress()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public AddressHelper SubmitAddressModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public AddressHelper InitAddressModofocation()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
        
    }
}


