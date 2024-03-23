
using Bybit.Net.Clients;
using ExchangeQuoteTracker.Model.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeQuoteTracker.Providers
{
    internal class BybitQuoteProvider : Provider, IExchangeQuoteProvider
    {
        private readonly BybitSocketClient bybitClient;
        public BybitQuoteProvider()
        {
            bybitClient = new BybitSocketClient(); Name = "Bybit.................";
        }
        async Task<decimal?> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            if (pair != null && bybitClient != null)
            {
                var tickerSubscriptionResult = await bybitClient.V5SpotApi.SubscribeToTickerUpdatesAsync(pair /*"BTCUSDT"*/, (update) =>
                {
                    if (update.Data.LastPrice != 0) LastPrice = update.Data.LastPrice;
                    else { throw new Exception("bybitClient update.Data.LastPrice = null"); }
                });
            }
            return LastPrice;
        }
    }
}
