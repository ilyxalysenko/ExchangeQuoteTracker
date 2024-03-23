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
using ExchangeQuoteTracker.Model.Providers;
namespace ExchangeQuoteTracker
{

    internal class BinanceQuoteProvider : Provider, IExchangeQuoteProvider
    {
        private readonly BinanceSocketClient binanceClient;
        decimal LastPrice;
        public BinanceQuoteProvider()
        {
            binanceClient = new BinanceSocketClient(); Name = "Binance";
        }
        
        async Task<decimal?> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            if (pair != null && binanceClient != null) 
            {
                var tickerSubscriptionResult = await binanceClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(pair /*"BTCUSDT"*/, (update) =>
                {
                    if (update.Data.LastPrice != 0) LastPrice = update.Data.LastPrice;
                    else { throw new Exception("binanceClient update.Data.LastPrice = null"); }
                });
            }
            return LastPrice;
        }
    }
}
