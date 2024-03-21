using CryptoExchange.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeQuoteTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            // Получение котировок с помощью провайдеров и обновление соответствующих элементов UI
            var binanceQuote = await binanceProvider.GetQuoteAsync("BTCUSDT");
            var bybitQuote = await bybitProvider.GetQuoteAsync("BTCUSDT");
            var kucoinQuote = await kucoinProvider.GetQuoteAsync("BTC-USDT");
            var bitgetQuote = await bitgetProvider.GetQuoteAsync("BTCUSDT");

            // Обновление элементов UI с новыми котировками
            listView1.Items.Clear();

            listView1.Items.Add($"{binanceQuote}");
            listView1.Items.Add($"{bybitQuote}");
            listView1.Items.Add($"{kucoinQuote}");
            listView1.Items.Add($"{bitgetQuote}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}