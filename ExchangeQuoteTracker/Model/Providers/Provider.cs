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
        string IExchangeQuoteProvider.Name { get; set; }

        public string GetName()
        {
            return "AbstractName";
        }

        Task<decimal?> IExchangeQuoteProvider.GetQuoteAsync(string pair)
        {
            throw new NotImplementedException();
        }
    }
}
