using System;
using NUnit.Framework;

namespace AccountingTestTDDWith91
{
    public class AccountingTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void No_Budget()
        {
            var accounting = new Accounting();
            var totalBudget = accounting.QueryBudget(
                new DateTime(2019, 4, 1), new DateTime(2019, 4, 1));
        }
    }

    public class Accounting
    {
        public decimal QueryBudget(DateTime dateTime, DateTime dateTime1)
        {
            return 0;
        }
    }
}