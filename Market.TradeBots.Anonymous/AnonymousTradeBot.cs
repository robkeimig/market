using System;
using Market.Query;
using Market.Trading;

namespace Market.TradeBots.Anonymous
{
    public class AnonymousTradeBot : ITradeBot
    {
        private readonly IQueryService _queryService;
        private readonly ITradingService _tradingService;

        public AnonymousTradeBot(IQueryService queryService, ITradingService tradingService)
        {
            _queryService = queryService;
            _tradingService = tradingService;
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
