using Binance.Net.Clients;
using ExchangeQuoteTracker.Model.Providers;
using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExchangeQuoteTracker
{
    internal class KucoinQuoteProvider: Provider, IExchangeQuoteProvider
    {
        private readonly KucoinSocketClient kucoinClient;
        decimal? LastPrice;
        public KucoinQuoteProvider()
        {
            kucoinClient = new KucoinSocketClient(); Name = "Kucoin";
        }
        async Task<decimal?> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            if (pair != null && kucoinClient != null)
            {
                var tickerSubscriptionResult = kucoinClient.SpotApi.SubscribeToTickerUpdatesAsync(pair/*"BTC-USDT"*/, (update) =>
                {
                    if(update.Data.LastPrice != 0) LastPrice = update.Data.LastPrice;
                    else { throw new Exception("kucoinClient update.Data.LastPrice = null"); }
                });
            }    
            return LastPrice;
        }
    }
}
