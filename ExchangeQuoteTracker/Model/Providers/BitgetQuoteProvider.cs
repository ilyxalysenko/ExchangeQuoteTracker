using Bitget.Net.Clients;
using ExchangeQuoteTracker.Model.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeQuoteTracker
{
    internal class BitgetQuoteProvider : Provider, IExchangeQuoteProvider
    {
        private readonly BitgetSocketClient bitgetClient;
        public BitgetQuoteProvider()
        {
            bitgetClient = new BitgetSocketClient(); Name = "Bitget ";
        }
        async Task<decimal?> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            if (pair != null && bitgetClient != null)
            {
                var tickerSubscriptionResult = await bitgetClient.SpotApi.SubscribeToTickerUpdatesAsync(pair /*"BTCUSDT"*/, (update) =>
                {
                    if (update.Data.LastPrice != 0) LastPrice = update.Data.LastPrice;
                    else { throw new Exception("bitgetClient update.Data.LastPrice = null"); }
                });
            }
            return LastPrice;
        }
    }
}
