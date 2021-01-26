using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {

        [Test]
        public void TestProjectCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root",               
            };
            ProjectData project = new ProjectData()
            {
                Name = "New Project",
                Status = "Development",
                Description = "Description"
            };
            app.Auth.Login(account);
            app.MenuHelper.GoToManagementPage();
            app.MenuHelper.GoToManageProjectTab();
            app.Pmh.Create(project);



        }
    }
}
