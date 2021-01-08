using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests

{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
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
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));

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
