using System;
using Market.Execution;
using Market.Query;
using Market.Trading;

namespace Market.TradeBots.Anonymous
{
    public class AnonymousTradeBot : ITradeBot
    {
        private readonly IQueryService _queryService;
        private readonly IExecutionService _executionService;

        public AnonymousTradeBot(IQueryService queryService, IExecutionService executionService)
        {
            _queryService = queryService;
            _executionService = executionService;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
