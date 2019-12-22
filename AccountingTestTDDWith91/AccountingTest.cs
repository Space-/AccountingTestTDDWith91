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

        [SetUp]
        public void Setup()
        {
            _budgetRepository = Substitute.For<IRepository>();
        }

        [Test]
        public void No_Budget()
        {
            _budgets = new List<Budget>();
            _budgetRepository.GetAll().Returns(_budgets);

            var accounting = new Accounting(_budgetRepository);
            var totalBudget = accounting.QueryBudget(
                new DateTime(2019, 4, 1), new DateTime(2019, 4, 1));

            Assert.AreEqual(0, totalBudget);
        }

        [Test]
        public void Period_Inside_Budget_Month()
        {
            _budgets = new List<Budget>()
            {
                new Budget() { YearMonth = "201904", Amount = 1 }
            };

            _budgetRepository.GetAll().Returns(_budgets);

            var accounting = new Accounting(_budgetRepository);
            var totalBudget = accounting.QueryBudget(
                new DateTime(2019, 4, 1), new DateTime(2019, 4, 1));

            Assert.AreEqual(1, totalBudget);
        }
    }

    public interface IRepository
    {
        List<Budget> GetAll();
    }

    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }
    }
}