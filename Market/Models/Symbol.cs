using System;
using System.Collections.Generic;

namespace Market.Models
{
    public class Symbol
    {
        public long Id { get; set; }

        public string SymbolId { get; set; }

        public string Name { get; set; }

        public string Exchange { get; set; }

        public DateTime? ListingDate { get; set; }

        public DateTime? UpdatedUtc { get; set; }

        public string Country { get; set; }

        public string Industry { get; set; }

        public string Sector { get; set; }

        public long? MarketCapitalization { get; set; }

        public long? Employees { get; set; }

        public string CeoName { get; set; }
    
        public string Url { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> SimilarSymbols { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
