using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeQuoteTracker.Model.Providers
{
    public abstract class Provider : IExchangeQuoteProvider
    {
        public string Name { get; set; }
        public decimal? LastPrice { get; set; }
        Task<decimal?> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            throw new NotImplementedException();
        }
    }
}
