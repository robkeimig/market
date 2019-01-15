using System;

namespace Market.Models
{
    public class Earnings
    {
        public long Id { get; set; }

        public long SymbolId { get; set; }

        public string Symbol { get; set; }

        public DateTime? EarningsReportDate { get; set; }

        public int FiscalYear { get; set; }

        public int FiscalQuarter { get; set; }

        public DateTime? FiscalEndDate { get; set; }

        public decimal? ActualEarningsPerShare { get; set; }

        public decimal? ConsensusEarningsPerShare { get; set; }

        public decimal? EstimatedEarningsPerShare { get; set; }

        public string AnnounceTime { get; set; }

        public int? NumberOfEstimates { get; set; }

        public decimal? EarningsPerShareSurpriseAmount { get; set; }
    }
}
