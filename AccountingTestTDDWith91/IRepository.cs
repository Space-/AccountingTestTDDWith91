using System.Collections.Generic;

namespace AccountingTestTDDWith91
{
    public interface IRepository
    {
        List<Budget> GetAll();
    }
}