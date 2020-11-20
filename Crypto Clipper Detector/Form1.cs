using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Crypto_Clipper_Detector
{
    public partial class Form1 : Form
    {
        string btc = "1cVCxwzaVzca3MXFDQuNfg7xQfXLzPq6Z";
        string bch = "pp8skudq3x5hzw8ew7vzsw8tn4k8wxsqsv0lt0mf3g";
        string ltc = "3CDJNfdWX8m2NwuGUV3nhXHXEeLygMXoAj";
        string eth = "0x931D387731bBbC988B312206c74F77D004D6B84b";
        string xmr = "888tNkZrPN6JsEgekjMnABU4TBzc2Dt29EPAvkRxbANsAnjyPbb3iQ1YBRk1UXcdRsiKc9dhwMVgN5S9cQUiyoogDavup3H";
        string selection = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Btc_CheckedChanged(object sender, EventArgs e)
        {
            selection = "btc";
        }

        private void Bch_CheckedChanged(object sender, EventArgs e)
        {
            selection = "bch";
        }

        private void Xmr_CheckedChanged(object sender, EventArgs e)
        {
            selection = "xmr";
        }

        private void Ltc_CheckedChanged(object sender, EventArgs e)
        {
            selection = "ltc";
        }

        private void Eth_CheckedChanged(object sender, EventArgs e)
        {
            selection = "eth";
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            if (selection == "btc")
                Checker(btc);
            else if (selection == "bch")
                Checker(bch);
            else if (selection == "ltc")
                Checker(ltc);
            else if (selection == "eth")
                Checker(eth);
            else if (selection == "xmr")
                Checker(xmr);
            else if (selection == "")
                statusLabel.Text = "Choose a cryptocoin first.";
        }

        private void Checker(string address)
        {
            Clipboard.SetText(address);
            statusLabel.Text = "Test address was copied!";
            wait(2000);
            statusLabel.Text = "Waiting 3 seconds...";
            wait(3000);
            string original = Clipboard.GetText(TextDataFormat.Text);
            if (original != address)
            {
                statusLabel.ForeColor = System.Drawing.Color.Red;
                statusLabel.Text = "Crypto clipper has been detected!";
            }
            else
            {
                statusLabel.ForeColor = System.Drawing.Color.Green;
                statusLabel.Text = "No crypto clipper was detected!";
            }
        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Start wait timer
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Stop wait timer
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
    }
}
    