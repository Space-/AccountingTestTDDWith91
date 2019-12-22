using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace AccountingTestTDDWith91
{
    public class AccountingTest
    {
        private List<Budget> _budgets;
        private IRepository _budgetRepository;
        private Accounting _accounting;

        [SetUp]
        public void TestInit()
        {
            _budgetRepository = Substitute.For<IRepository>();
            _accounting = new Accounting(_budgetRepository);
        }

        [Test]
        public void No_Budget()
        {
            _budgets = new List<Budget>();
            GivenBudget(_budgets);

            _accounting = new Accounting(_budgetRepository);
            var totalBudget = _accounting.QueryBudget(
                new DateTime(2019, 4, 1), new DateTime(2019, 4, 1));

            Assert.AreEqual(0, totalBudget);
        }

        private void GivenBudget(List<Budget> budgets)
        {
            _budgetRepository.GetAll().Returns(budgets);
        }

        [Test]
        public void Period_Inside_Budget_Month()
        {
            _budgets = new List<Budget>()
            {
                new Budget() { YearMonth = "201904", Amount = 1 }
            };

            GivenBudget(_budgets);

            var totalBudget = _accounting.QueryBudget(
                new DateTime(2019, 4, 1), new DateTime(2019, 4, 1));

            Assert.AreEqual(1, totalBudget);
        }
    }
}