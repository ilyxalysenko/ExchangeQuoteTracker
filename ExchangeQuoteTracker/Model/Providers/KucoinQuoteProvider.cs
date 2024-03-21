using Binance.Net.Clients;
using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeQuoteTracker
{
    internal class KucoinQuoteProvider:IExchangeQuoteProvider
    {
        private readonly KucoinSocketClient kucoinClient;
        decimal LastPrice;
        public KucoinQuoteProvider()
        {
            kucoinClient = new KucoinSocketClient();
        }
        async Task<decimal> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            //var ticker = await kucoinClient.SpotApi.ExchangeData.GetCurrentAvgPriceAsync(pair);//get price async pair
            //return ticker.Data.Result.Price; //REST
            var tickerSubscriptionResult = kucoinClient.SpotApi.SubscribeToTickerUpdatesAsync(pair/*"BTC-USDT"*/, (update) =>
            {
                var lastPrice = update.Data.LastPrice;
            });
            return this.LastPrice;
        }
        //async Task<List<string>> IExchangeQuoteProvider.GetAvailablePairs()//получить список доступных на бирже торговых пар
        //{
        //    var exchangeInfo = await kucoinClient.FuturesApi;//получение информации об обмене данными на бирже
        //    return exchangeInfo.Data.Result.Symbols.Select(s => s.Name).ToList();//имена символов (торговых пар) из результирующего списка метод помещает их в список
        //}
    }
}
