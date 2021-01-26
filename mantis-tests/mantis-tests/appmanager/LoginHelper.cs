using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{

    public class LoginHelper : HelperBase

    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("navbar"));
            throw new NotImplementedException();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Name;
        }

        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.CssSelector("span.user-info")).Text;
            return text;
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("a.dropdown-toggle")).Click();
                driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-sign-out")).Click();
            }
        }
    }
}
