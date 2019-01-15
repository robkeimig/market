using System;
using Market.Execution;
using Market.Query;
using Market.Trading;

namespace Market.TradeBots.Rob
{
    public class RobsTradeBot : ITradeBot
    {
        private readonly IQueryService _queryService;
        private readonly IExecutionService _executionService;

        public RobsTradeBot(IQueryService queryService, IExecutionService executionService)
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
