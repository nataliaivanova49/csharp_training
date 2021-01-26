using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectManagementHelper Create(ProjectData project)
        {
            InitProjectCreation();
            FillProjectForm(project);
            AddProject();
            return this;
        }

        private void AddProject()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            //new SelectElement(driver.FindElement(By.Name("status"))).SelectByText(project.Status);
            //new SelectElement(driver.FindElement(By.Name("view_state"))).SelectByText(project.ViewStatus);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }

        private void InitProjectCreation()
        {
            driver.FindElements(By.CssSelector("button.btn.btn-primary.btn-white.btn-round"))[0].Click();
        }

        internal ProjectManagementHelper Remove(ProjectData project)
        {
            if (!IsElementPresent(By.CssSelector("div.table-responsive"))) 
            {
                Create(project);
            }
            InitProjectRemoval();
            DeleteProject();
            return this;
        }

        private void DeleteProject()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
        }

        private void InitProjectRemoval()
        {
            driver.FindElements(By.TagName("tbody"))[0].FindElements(By.TagName("tr"))[0]
                .FindElements(By.TagName("td"))[0].FindElement(By.TagName("a")).Click();
        }
    }
}
    
