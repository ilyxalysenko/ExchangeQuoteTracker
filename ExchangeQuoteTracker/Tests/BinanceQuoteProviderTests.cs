using Binance.Net.Clients;
using Binance.Net.Objects.Models.Spot.Socket;
using ExchangeQuoteTracker.Model.Providers;
using Moq;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ExchangeQuoteTracker.Tests
{
    [TestFixture]
    public class BinanceQuoteProviderTests
    {
        [Test]
        public async Task GetQuoteAsync_WithValidPair_ReturnsLastPrice()
        {
            // Arrange
            string validPair = "BTCUSDT";
            decimal expectedLastPrice = 100.00m;

            var binanceClientMock = new Mock<BinanceSocketClient>();
            binanceClientMock
                .Setup(client => client.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(validPair, It.IsAny<System.Action<BinanceStreamTick>>()))
                .Callback<string, System.Action<BinanceStreamTick>>((pair, callback) =>
                {
                    // Simulate receiving a tick update
                    var update = new BinanceStreamTick { Symbol = pair, Data = new BinanceStreamTickData { LastPrice = expectedLastPrice } };
                    callback.Invoke(update);
                })
                .ReturnsAsync(() => { });

            var quoteProvider = new BinanceQuoteProvider { binanceClient = binanceClientMock.Object };

            // Act
            decimal? result = await quoteProvider.GetQuoteAsync(validPair);

            // Assert
            Assert.AreEqual(expectedLastPrice, result);
        }

        [Test]
        public async Task GetQuoteAsync_WithNullPair_ReturnsNull()
        {
            // Arrange
            string invalidPair = null;
            decimal? expectedLastPrice = null;

            var binanceClientMock = new Mock<BinanceSocketClient>();

            var quoteProvider = new BinanceQuoteProvider { binanceClient = binanceClientMock.Object };

            // Act
            decimal? result = await quoteProvider.GetQuoteAsync(invalidPair);

            // Assert
            Assert.AreEqual(expectedLastPrice, result);
        }
    }
}
