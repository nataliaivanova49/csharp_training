using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTests()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData() 
            {
                Id = "6"
            };
            IssueData issue = new IssueData() 
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "General"
            };
            app.APIHelper.CreateNewIssue(account, issue, project);
        }
    }
}
