using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ending_Balance_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            const decimal INTEREST_RATE = 0.005m;

            decimal balance;
            int months;
            int count = 1;

            if (decimal.TryParse(startingBalTextBox.Text, out balance))
            {
                if (int.TryParse(monthsTextBox.Text, out months))
                {
                    while (count <= months)
                    {
                        balance = balance + (INTEREST_RATE * balance);

                        detailListBox.Items.Add("The ending balance " + "for month " + count + " is " + balance.ToString("c"));

                        count = count + 1;
                    }
                    endingBalanceLabel.Text = balance.ToString("c");
                }
                else
                {
                    MessageBox.Show("Invalid value for months.");
                }
            }
            else
            {
                MessageBox.Show("Invalid value for starting balance.");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            startingBalTextBox.Text = "";
            monthsTextBox.Text = "";
            endingBalanceLabel.Text = "";
            detailListBox.Items.Clear();

            startingBalTextBox.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
