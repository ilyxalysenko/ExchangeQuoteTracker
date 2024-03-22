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
        static string Name = "Kucoin";

        private readonly KucoinSocketClient kucoinClient;
        decimal? LastPrice;
        public KucoinQuoteProvider()
        {
            kucoinClient = new KucoinSocketClient();
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
        string IExchangeQuoteProvider.GetName() { return Name; }
        //async Task<List<string>> IExchangeQuoteProvider.GetAvailablePairs()//получить список доступных на бирже торговых пар
        //{
        //    var exchangeInfo = await kucoinClient.FuturesApi;//получение информации об обмене данными на бирже
        //    return exchangeInfo.Data.Result.Symbols.Select(s => s.Name).ToList();//имена символов (торговых пар) из результирующего списка метод помещает их в список
        //}
    }
}
