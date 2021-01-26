using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {

        [Test]
        public void TestProjectRemoval()
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
            app.Pmh.Remove(project);
        }
    }
}
