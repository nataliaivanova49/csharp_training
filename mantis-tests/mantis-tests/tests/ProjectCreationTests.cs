using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
            ProjectData project = new ProjectData("New Project")
            {
                
                Status = "Development",
                Description = "Description"
            };
            app.Auth.Login(account);
            app.MenuHelper.GoToManagementPage();
            app.MenuHelper.GoToManageProjectTab();
            List<ProjectData> oldProjects = app.Pmh.GetProjectList();
            app.Pmh.Create(project);
            List<ProjectData> newProjects = app.Pmh.GetProjectList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);



        }
    }
}
