﻿
using Bybit.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeQuoteTracker.Providers
{
    internal class BybitQuoteProvider : IExchangeQuoteProvider
    {
        private readonly BybitSocketClient bybitClient;
        decimal LastPrice;
        public BybitQuoteProvider()
        {
            bybitClient = new BybitSocketClient();
        }
        async Task<decimal> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            //var ticker = await binanceClient.SpotApi.ExchangeData.GetCurrentAvgPriceAsync(pair);//get price async pair
            //return ticker.Data.Result.Price; //REST
            var tickerSubscriptionResult = bybitClient.V5SpotApi.SubscribeToTickerUpdatesAsync(pair /*"BTCUSDT"*/, (update) =>
            {
                var lastPrice = update.Data.LastPrice;
            });
            return LastPrice;
        }

        //async Task<List<string>> IExchangeQuoteProvider.GetAvailablePairs()//получить список доступных на бирже торговых пар
        //{
        //    var exchangeInfo = await binanceClient.SpotApi.ExchangeData.GetExchangeInfoAsync();//получение информации об обмене данными на бирже
        //    return exchangeInfo.Data.Result.Symbols.Select(s => s.Name).ToList();//имена символов (торговых пар) из результирующего списка метод помещает их в список
        //}
    }
}
