
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
        static string Name = "Bybit";

        private readonly BybitSocketClient bybitClient;
        decimal LastPrice;
        public BybitQuoteProvider()
        {
            bybitClient = new BybitSocketClient();
        }
        async Task<decimal?> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            if (pair != null && bybitClient != null)
            {
                var tickerSubscriptionResult = bybitClient.V5SpotApi.SubscribeToTickerUpdatesAsync(pair /*"BTCUSDT"*/, (update) =>
                {
                    if (update.Data.LastPrice != 0) LastPrice = update.Data.LastPrice;
                    else { throw new Exception("bybitClient update.Data.LastPrice = null"); }
                });
            }
            return LastPrice;
        }
        string IExchangeQuoteProvider.GetName() { return Name; }
        //async Task<List<string>> IExchangeQuoteProvider.GetAvailablePairs()//получить список доступных на бирже торговых пар
        //{
        //    var exchangeInfo = await binanceClient.SpotApi.ExchangeData.GetExchangeInfoAsync();//получение информации об обмене данными на бирже
        //    return exchangeInfo.Data.Result.Symbols.Select(s => s.Name).ToList();//имена символов (торговых пар) из результирующего списка метод помещает их в список
        //}
    }
}
