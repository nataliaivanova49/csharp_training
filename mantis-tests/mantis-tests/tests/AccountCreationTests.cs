﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetUpConfig() 
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
             
            AccountData account = new AccountData()
            {
                Name = "testuserewr",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if(existingAccount != null)
            {
                app.Admin.DeleteAccount(account);
            }
            
            app.Registration.Register(account);

        }

        [TestFixtureTearDown]
        public void RestoreConfig() 
        {
            app.Ftp.RestoreBackupFile("");
        }
    }
}
