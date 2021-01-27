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
            ProjectData project = new ProjectData("New ProjectR")
            {
               
                Status = "Development",
                Description = "Description"
            };
            app.Auth.Login(account);
            app.MenuHelper.GoToManagementPage();
            app.MenuHelper.GoToManageProjectTab();
            
            List<ProjectData> oldProjects = app.Pmh.GetProjectList();
            if (oldProjects.Count == 0)
            {
                app.Pmh.Create(project);
                oldProjects.Add(project);
                oldProjects.Sort();
                app.MenuHelper.GoToManageProjectTab();
            }           
            
            app.Pmh.Remove();

            List<ProjectData> newProjects = app.Pmh.GetProjectList();
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);
            
        }
    }
}
