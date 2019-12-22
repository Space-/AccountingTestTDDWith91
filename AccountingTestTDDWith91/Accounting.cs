using System;
using System.Linq;
using System.Net;

namespace AccountingTestTDDWith91
{
    public class Accounting
    {
        private IRepository _budgetRepository;

        public Accounting(IRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public decimal QueryBudget(DateTime startDate, DateTime endDate)
        {
            var currentYearMonth = startDate.ToString("yyyyMM");
            var budget = _budgetRepository.GetAll().FirstOrDefault(x => x.YearMonth == currentYearMonth);

            return budget?.Amount ?? 0;
        }
    }
}