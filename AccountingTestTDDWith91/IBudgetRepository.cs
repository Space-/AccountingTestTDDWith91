using System.Collections.Generic;

namespace AccountingTestTDDWith91
{
    public interface IBudgetRepository
    {
        List<Budget> GetAll();
    }
}