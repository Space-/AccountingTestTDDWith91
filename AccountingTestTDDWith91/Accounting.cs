using System.Linq;

namespace AccountingTestTDDWith91
{
    public class Accounting
    {
        private readonly IBudgetRepository _budgetRepository;

        public Accounting(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public decimal QueryBudgetInPeriod(Period period)
        {
            var currentYearMonth = period.StartDate.ToString("yyyyMM");
            var budget = _budgetRepository.GetAll().FirstOrDefault(x => x.YearMonth == currentYearMonth);

            return budget?.Amount ?? 0;
        }
    }
}