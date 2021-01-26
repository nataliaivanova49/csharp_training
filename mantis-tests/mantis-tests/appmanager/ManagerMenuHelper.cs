using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{    
    public class ManagerMenuHelper : HelperBase
    {
        public ManagerMenuHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void GoToManagementPage() 
        {
            driver.FindElements(By.CssSelector("span.menu-text"))[6].Click();
        }
        public void GoToManageProjectTab()
        {
            driver.FindElement(By.CssSelector("ul.nav.nav-tabs.padding-18"))
                .FindElements(By.TagName("li"))[2].Click();
            
        }
    }
}
