using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace mantis_tests

{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;

        protected ApplicationManager app;

        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));

            }
            return builder.ToString();
        }
        public static string GenerateRandomInt(int size)
        {
           
            int result = 0;
            for (int i = 0; i < size; i++)
            {

                result = (int)((result * 10) + (rnd.NextDouble() * 9));
                if (size > 1 && result == 0)
                    result++;
            }

            return result.ToString();
        }
    }
}
