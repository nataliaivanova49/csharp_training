using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAddressbookTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double total = 1500;
            if(total > 1000) 
            {
                total = total * 0.9;
                Console.Out.Write("Скидка 10%, общая сумма" + total);
            }
            else 
            {
                Console.Out.Write("Скидки нет, общая сумма" + total);
            }
        }
    }
}
