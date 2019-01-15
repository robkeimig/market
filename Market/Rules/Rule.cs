using Market.Query;
using Market.Repositories;
using Market.Trading;

namespace Market.Rules
{
    public partial class Rule
    {
        private readonly ISymbolRepository _symbolRepository;
        private readonly ITradingService _executionService;
        private readonly IQueryService _queryService;

        public Rule(
            ISymbolRepository symbolRepository,
            ITradingService executionService,
            IQueryService queryService)
        {
            _symbolRepository = symbolRepository;
            _executionService = executionService;
            _queryService = queryService;
        }
    }
}
