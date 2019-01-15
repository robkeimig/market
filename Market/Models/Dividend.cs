using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Models
{
    public class Dividend
    {
        public long Id { get; set; }

        public string Symbol { get; set; }

        public DateTime? ExDividendDate { get; set; }

        public DateTime? RecordDate { get; set; }

        public DateTime? DeclaredDate { get; set; }

        public decimal Amount { get; set; }

        public DividendQualification Qualification { get; set; }

        public DividendFlag Flag { get; set; }
    }
}
