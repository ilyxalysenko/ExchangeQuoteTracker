using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Binance.Net;
using Binance.Net.Clients;
using Binance.Net.Objects.Models.Spot.Socket;
using CryptoExchange.Net.Authentication;
using System.Collections.Generic;
using Binance.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using CryptoExchange.Net.Interfaces;
using System.Linq;
namespace ExchangeQuoteTracker
{

    public class BinanceQuoteProvider : IExchangeQuoteProvider
    {
        private readonly BinanceSocketClient binanceClient;
        decimal LastPrice;
        public BinanceQuoteProvider()
        {
            binanceClient = new BinanceSocketClient();
        }
        async Task<decimal> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        { 
            var tickerSubscriptionResult = binanceClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(pair /*"BTCUSDT"*/, (update) =>
            {
                LastPrice = update.Data.LastPrice;
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
