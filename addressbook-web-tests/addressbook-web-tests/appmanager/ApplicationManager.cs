using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected bool acceptNextAlert;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected LogoutHelper logoutHelper;
        protected AddressHelper addressHelper;

        public ApplicationManager()
        {
            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            logoutHelper = new LogoutHelper(driver);
            addressHelper = new AddressHelper(driver, acceptNextAlert);
        }
        public void Stop() 
        { }
        public LoginHelper Auth 
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator 
        {
            get 
            {
                return navigator;
            }
        }
        public GroupHelper Groups 
        {
            get
            {
                return groupHelper;
            }
        }
        public LogoutHelper Logout
        {
            get
            {
                return logoutHelper;
            }
        }
        public AddressHelper Address
        {
            get
            {
                return addressHelper;
            }
        }

  
    }
}
