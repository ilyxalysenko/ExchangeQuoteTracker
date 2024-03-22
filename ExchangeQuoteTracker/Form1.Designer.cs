using ExchangeQuoteTracker.Providers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeQuoteTracker
{
    partial class Form1 : Form
    {
        private Timer timer;

        List<IExchangeQuoteProvider> Provs;

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            Provs = new List<IExchangeQuoteProvider>()
            {
                new BinanceQuoteProvider(),
                new BybitQuoteProvider(),
                new KucoinQuoteProvider(),
                new BitgetQuoteProvider(),
            };
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(-1, 26);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(328, 424);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "BTCUSDT",
            "ETHUSDT",
            "BTCUSD",
            "SOLUSDT",
            "ETHUSD",
            "ETHUSDC",
            "POLYXKRW",
            "PEPEUSDT"});
            this.comboBox1.Location = new System.Drawing.Point(-1, -2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(328, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Quotes App";
            this.ResumeLayout(false);

        }

        private void Timer_Tick1(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

