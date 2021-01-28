using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private const string CssSelectorToFind = "table.table.table-striped.table-bordered.table-condensed.table-hover";
        private string baseUrl;
        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }
        public List<AccountData> GetAllAccounts() 
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElement(By.CssSelector(CssSelectorToFind))
                .FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows) 
            {
                string name = row.FindElements(By.TagName("td"))[0].FindElement(By.TagName("a")).Text;
                string href = row.FindElements(By.TagName("td"))[0].FindElement(By.TagName("a")).GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });
            }
            return accounts;
        }
        public void DeleteAccount(AccountData account) 
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("input[value='Delete User']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Account']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();

            driver.Url = baseUrl + "/login_page.php";

            driver.FindElement(By.Id("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.Id("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

           
            return driver;
        }
    }
}
