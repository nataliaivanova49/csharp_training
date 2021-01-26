using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests

{
    public class ApplicationManager
    {
        protected IWebDriver driver;    
        protected string baseURL;
       

        public RegistrationHelper Registration { get; private set; }
        public FtpHelper Ftp { get; private set; }
        public LoginHelper loginHelper;
        public ManagerMenuHelper menuHelper;
        public ProjectManagementHelper projectManagementHelper;

        public static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
             
        public ApplicationManager()
        {
            driver = new FirefoxDriver();           
            baseURL = "http://localhost/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
            menuHelper = new ManagerMenuHelper(this);
            projectManagementHelper = new ProjectManagementHelper(this);
        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                //Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance() 
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();                
                newInstance.driver.Url = "http://localhost/mantisbt-2.24.4/mantisbt-2.24.4/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
            }        
        
        public IWebDriver Driver 
        {
            get 
            {
                return driver;
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public ManagerMenuHelper MenuHelper
        {
            get
            {
                return menuHelper;
            }
        }
        public ProjectManagementHelper Pmh
        {
            get
            {
                return projectManagementHelper;
            }
        }
    }
}
