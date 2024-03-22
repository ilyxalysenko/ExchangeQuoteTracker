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
        static string Name = "Bitget";

        private readonly BitgetSocketClient bitgetClient;
        decimal LastPrice;
        public BitgetQuoteProvider()
        {
            bitgetClient = new BitgetSocketClient();
        }
        async Task<decimal?> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            if (pair != null && bitgetClient != null)
            {
                var tickerSubscriptionResult = bitgetClient.SpotApi.SubscribeToTickerUpdatesAsync(pair /*"BTCUSDT"*/, (update) =>
                {
                    if (update.Data.LastPrice != 0) LastPrice = update.Data.LastPrice;
                    else { throw new Exception("bitgetClient update.Data.LastPrice = null"); }
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
