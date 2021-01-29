using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Name = "New project",
                Status = "Development",
                Description = "Description"
            };
            app.Auth.Login(account);
            app.MenuHelper.GoToManagementPage();
            app.MenuHelper.GoToManageProjectTab();
            
            List<ProjectData> oldProjects = app.APIHelper.GetProjectList(account);
            if (oldProjects.Count == 0)
            {
                app.APIHelper.Create(account, project);
                app.MenuHelper.GoToManageProjectTab();
            }
            List<ProjectData> projectBeforeRemove = app.APIHelper.GetProjectList(account);

            app.Pmh.Remove();

            List<ProjectData> newProjects = app.APIHelper.GetProjectList(account);
            projectBeforeRemove.RemoveAt(0);
            Assert.AreEqual(projectBeforeRemove, newProjects);
            
        }
    }
}
