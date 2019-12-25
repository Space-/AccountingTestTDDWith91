using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace AccountingTestTDDWith91
{
    public class AccountingTest
    {
        private IBudgetRepository _budgetRepository;
        private Accounting _accounting;
        private Period _budgetPeriod;

        [SetUp]
        public void TestInit()
        {
            _budgetRepository = Substitute.For<IBudgetRepository>();
            _accounting = new Accounting(_budgetRepository);
        }

        [Test]
        public void No_Budget()
        {
            GivenBudgets(new List<Budget>());
            GivenPeriod(new Period(new DateTime(2019, 4, 1), new DateTime(2019, 4, 1)));
            TotalBudgetShouldBe(0);
        }

        [Test]
        public void Period_Inside_Budget_Month()
        {
            GivenBudgets(new List<Budget>
            {
                new Budget() { YearMonth = "201904", Amount = 1 }
            });

            GivenPeriod(new Period(new DateTime(2019, 4, 1), new DateTime(2019, 4, 1)));
            TotalBudgetShouldBe(1);
        }

        private void GivenPeriod(Period budgetPeriod)
        {
            _budgetPeriod = budgetPeriod;
        }

        private void GivenBudgets(List<Budget> budgets)
        {
            _budgetRepository.GetAll().Returns(budgets);
        }

        private void TotalBudgetShouldBe(int expected)
        {
            Assert.AreEqual(expected, _accounting.QueryBudgetInPeriod(_budgetPeriod));
        }
    }
}