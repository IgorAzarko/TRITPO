using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Z.Expressions;

namespace Calculator_
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        public void handleBtnClick(object sender, MouseEventArgs e)
        {
            
            string operation = (sender as Button).Text;
            labelResult.Text += operation;
        }

        private void operationBtnClick(object sender, MouseEventArgs e)
        {
            string operation = (sender as Button).Text;
            labelResult.Text += operation;
        }

        private void btnPlotter_Click(object sender, EventArgs e)
        {
            Plotter plotter = new Plotter();
            plotter.Show();
        }

        private void deleteResultSymbol(object sender, MouseEventArgs e)
        {
            if (labelResult.Text.Length > 0)
            {
                labelResult.Text = labelResult.Text.Substring(0, labelResult.Text.Length - 1);
            }
        }

        private void deleteAllResultSymbols(object sender, MouseEventArgs e)
        {
            labelResult.Text = "";
        }

        private void calculateResult(object sender, MouseEventArgs e)
        {
            labelResult.Text = Eval.Execute<double>(labelResult.Text).ToString();
        }
    }
}
