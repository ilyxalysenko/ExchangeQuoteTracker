using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeQuoteTracker
{
    internal interface IExchangeQuoteProvider
    {
        Task<decimal> GetQuoteAsync(string pair);
        //Task<List<string>> GetAvailablePairs();
    }
}
