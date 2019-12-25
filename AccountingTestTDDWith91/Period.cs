using System;

namespace AccountingTestTDDWith91
{
    public class Period
    {
        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}