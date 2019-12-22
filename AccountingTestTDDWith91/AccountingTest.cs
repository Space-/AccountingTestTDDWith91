using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace AccountingTestTDDWith91
{
    public class AccountingTest
    {
        private IBudgetRepository _budgetBudgetRepository;
        private Accounting _accounting;

        [SetUp]
        public void TestInit()
        {
            _budgetBudgetRepository = Substitute.For<IBudgetRepository>();
            _accounting = new Accounting(_budgetBudgetRepository);
        }

        [Test]
        public void No_Budget()
        {
            GivenBudgets(new List<Budget>());
            TotalBudgetShouldBe(0, new DateTime(2019, 4, 1), new DateTime(2019, 4, 1));
        }

        [Test]
        public void Period_Inside_Budget_Month()
        {
            GivenBudgets(new List<Budget>
            {
                new Budget() { YearMonth = "201904", Amount = 1 }
            });

            TotalBudgetShouldBe(1, new DateTime(2019, 4, 1), new DateTime(2019, 4, 1));
        }

        private void TotalBudgetShouldBe(int expected, DateTime startDate, DateTime endDate)
        {
            Assert.AreEqual(expected, _accounting.QueryBudget(startDate, endDate));
        }

        private void GivenBudgets(List<Budget> budgets)
        {
            _budgetBudgetRepository.GetAll().Returns(budgets);
        }
    }
}