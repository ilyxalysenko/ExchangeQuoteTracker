using CryptoExchange.Net;
using ExchangeQuoteTracker.Providers;
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
        private string Symbol;
        //private List<Label> quoteLabels;
        //private List<Label> nameLabels;

        public Form1()
        {
            InitializeComponent();
            Provs = new List<IExchangeQuoteProvider>()
            {
                new BinanceQuoteProvider(),
                new BybitQuoteProvider(),
                new KucoinQuoteProvider(),
                new BitgetQuoteProvider(),
            };
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            AddQuotesToListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        async void AddQuotesToListView()
        {
            if (comboBox1.SelectedItem != null)
            {
                Symbol = comboBox1.SelectedItem.ToString();
                listView1.Items.Clear();
                for (int i = 0; i < Provs.Count; i++)
                {
                    var provider = Provs[i];
                    string name = provider.GetName();
                    decimal? quote;

                    if (i == 2)
                    {
                        quote = await provider.GetQuoteAsync(Symbol.Insert(3, "-")); //Для кукоина нужен разделитель
                    }
                    else
                    {
                        quote = await provider.GetQuoteAsync(Symbol);
                    }

                    listView1.Items.Add($"{quote} {name}");
                }
            }
        }
    }
}