using System;
using System.Windows.Forms;

namespace Calculator_
{
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;

    public partial class Plotter : Form
    {
        public Plotter()
        {
            InitializeComponent();
            configurePlotModel();
            dataGridView1.AllowUserToAddRows = false;
        }

        private Func<double, double> functionalCreator(string functionText)
        {
            return value =>
            {
                return PolishNotation.Expression.Calculate(functionText, value);
            };
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                PolishNotation.Expression.Calculate(functionText.Text);    
                dataGridView1.Rows.Add(functionText.Text, "Удалить");
                configurePlotModel();
            }
            catch (Exception) {}

            functionText.Text = "";
        }

        private void configurePlotModel()
        {
            var pm = new PlotModel
            {
                PlotType = PlotType.Cartesian,
                Background = OxyColors.White
            };

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["function"].Value != null)
                {
                    var function = row.Cells["function"].Value.ToString();
                    pm.Series.Add(new FunctionSeries(functionalCreator(function), -10, 10, 0.1, function));
                }
            }

            pm.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MaximumPadding = 0.1, MinimumPadding = 0.1 });
            pm.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1 });

            plotView1.Model = pm;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var button = sender as DataGridViewButtonColumn;
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                configurePlotModel();
            } catch (Exception) {}
        }
    }
}
