using System;
using System.Linq;
using System.Net;

namespace AccountingTestTDDWith91
{
    public class Accounting
    {
        private IBudgetRepository _budgetBudgetRepository;

        public Accounting(IBudgetRepository budgetBudgetRepository)
        {
            _budgetBudgetRepository = budgetBudgetRepository;
        }

        public decimal QueryBudget(DateTime startDate, DateTime endDate)
        {
            var currentYearMonth = startDate.ToString("yyyyMM");
            var budget = _budgetBudgetRepository.GetAll().FirstOrDefault(x => x.YearMonth == currentYearMonth);

            return budget?.Amount ?? 0;
        }
    }
}