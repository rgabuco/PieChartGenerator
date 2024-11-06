using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PieChart
{
    public partial class Form1 : Form
    {
        private string[] labels;
        private double[] values;
        private Label dummyLabel;

        public Form1()
        {
            InitializeComponent();
            SetPlaceholderText();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a dummy label and add it to the form
            dummyLabel = new Label();
            dummyLabel.Size = new Size(0, 0); // Make it invisible
            this.Controls.Add(dummyLabel);

            // Set the dummy label as the active control
            this.ActiveControl = dummyLabel;
        }

        private void SetPlaceholderText()
        {
            txtLabelList.Text = "label1, label2, label3";
            txtLabelList.ForeColor = Color.Gray;
            txtValuesList.Text = "10,20,30";
            txtValuesList.ForeColor = Color.Gray;

            txtLabelList.Enter += RemovePlaceholderText;
            txtLabelList.Leave += SetPlaceholderText;
            txtValuesList.Enter += RemovePlaceholderText;
            txtValuesList.Leave += SetPlaceholderText;
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.ForeColor == Color.Gray)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == txtLabelList)
                {
                    textBox.Text = "label1, label2, label3";
                }
                else if (textBox == txtValuesList)
                {
                    textBox.Text = "10,20,30";
                }
                textBox.ForeColor = Color.Gray;
            }
        }

        private void btnGeneratePieChart_Click(object sender, EventArgs e)
        {
            if (txtLabelList.ForeColor == Color.Gray || txtValuesList.ForeColor == Color.Gray)
            {
                MessageBox.Show("Please enter valid labels and values.");
                return;
            }

            labels = txtLabelList.Text.Split(',');
            string[] valuesStr = txtValuesList.Text.Split(',');

            if (labels.Length != valuesStr.Length)
            {
                MessageBox.Show("The number of labels must match the number of values.");
                return;
            }

            values = new double[valuesStr.Length];
            for (int i = 0; i < valuesStr.Length; i++)
            {
                values[i] = double.Parse(valuesStr[i].Trim());
            }

            pieChartPanel.Invalidate();
            UpdateLegend();
        }

        private void pieChartPanel_Paint(object sender, PaintEventArgs e)
        {
            if (labels == null || values == null)
                return;

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(10, 10, pieChartPanel.Width - 20, pieChartPanel.Height - 20);
            float total = (float)values.Sum();
            float startAngle = 0;

            for (int i = 0; i < values.Length; i++)
            {
                float sweepAngle = (float)(values[i] / total) * 360; // Calculate the angle for the current value
                g.FillPie(new SolidBrush(GetColor(i)), rect, startAngle, sweepAngle);

                // Calculate the angle for the text
                float textAngle = startAngle + sweepAngle / 2;
                double radians = textAngle * Math.PI / 180;
                float x = (float)(rect.X + rect.Width / 2 + (rect.Width / 2.5) * Math.Cos(radians));
                float y = (float)(rect.Y + rect.Height / 2 + (rect.Height / 2.5) * Math.Sin(radians));

                // Measure the size of the text
                string valueText = values[i].ToString();
                SizeF textSize = g.MeasureString(valueText, this.Font);

                // Draw the white background rectangle
                g.FillRectangle(Brushes.White, x - textSize.Width / 2, y - textSize.Height / 2, textSize.Width, textSize.Height);

                // Draw the value text
                g.DrawString(valueText, this.Font, Brushes.Black, x - textSize.Width / 2, y - textSize.Height / 2);

                startAngle += sweepAngle;
            }
        }

        private void UpdateLegend()
        {
            // Clear existing legend labels
            foreach (Control control in this.Controls.OfType<Label>().Where(l => l.Name.StartsWith("legendLabel") || l.Name == "legendHeader").ToList())
            {
                this.Controls.Remove(control);
            }

            // Add legend header
            Label legendHeader = new Label
            {
                Name = "legendHeader",
                Text = "Legend:",
                Location = new Point(pieChartPanel.Right + 20, pieChartPanel.Top + 10), // Align to the right of the pie chart panel
                AutoSize = true,
                Font = new Font(this.Font, FontStyle.Bold)
            };
            this.Controls.Add(legendHeader);

            // Add legend labels
            for (int i = 0; i < labels.Length; i++)
            {
                Label legendLabel = new Label
                {
                    Name = $"legendLabel{i}",
                    Text = $"{labels[i].Trim()}: {values[i].ToString()}",
                    ForeColor = GetColor(i),
                    Location = new Point(pieChartPanel.Right + 22, pieChartPanel.Top + 40 + i * 20), // Adjust position relative to the header
                    AutoSize = true
                };
                this.Controls.Add(legendLabel);
            }
        }

        private Color GetColor(int index)
        {
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Black, Color.Orange, Color.Purple, Color.Brown, Color.Cyan, Color.Gray, Color.HotPink };
            return colors[index % colors.Length];
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtLabelList.Text = string.Empty;
            txtValuesList.Text = string.Empty;
        }
    }
}
