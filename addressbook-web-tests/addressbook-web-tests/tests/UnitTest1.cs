using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = null;
            int attempt = 0;
            while  (driver.FindElements(By.Id("test")).Count == 0 && attempt<60)
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }
        }
    }
}
