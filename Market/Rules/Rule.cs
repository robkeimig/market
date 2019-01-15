using Market.Execution;
using Market.Query;
using Market.Repositories;

namespace Market.Rules
{
    public partial class Rule
    {
        private readonly ISymbolRepository _symbolRepository;
        private readonly IExecutionService _executionService;
        private readonly IQueryService _queryService;

        public Rule(
            ISymbolRepository symbolRepository,
            IExecutionService executionService,
            IQueryService queryService)
        {
            _symbolRepository = symbolRepository;
            _executionService = executionService;
            _queryService = queryService;
        }
    }
}
