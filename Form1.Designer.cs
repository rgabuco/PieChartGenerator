namespace PieChart
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblList = new Label();
            txtLabelList = new TextBox();
            txtValuesList = new TextBox();
            label1 = new Label();
            btnGeneratePieChart = new Button();
            pieChartPanel = new Panel();
            btnReset = new Button();
            SuspendLayout();
            // 
            // lblList
            // 
            lblList.AutoSize = true;
            lblList.Location = new Point(23, 41);
            lblList.Name = "lblList";
            lblList.Size = new Size(83, 15);
            lblList.TabIndex = 0;
            lblList.Text = "Enter label list:";
            // 
            // txtLabelList
            // 
            txtLabelList.Location = new Point(128, 38);
            txtLabelList.Name = "txtLabelList";
            txtLabelList.Size = new Size(208, 23);
            txtLabelList.TabIndex = 1;
            // 
            // txtValuesList
            // 
            txtValuesList.Location = new Point(128, 67);
            txtValuesList.Name = "txtValuesList";
            txtValuesList.Size = new Size(208, 23);
            txtValuesList.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 70);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 2;
            label1.Text = "Enter Values List:";
            // 
            // btnGeneratePieChart
            // 
            btnGeneratePieChart.Location = new Point(23, 107);
            btnGeneratePieChart.Name = "btnGeneratePieChart";
            btnGeneratePieChart.Size = new Size(128, 32);
            btnGeneratePieChart.TabIndex = 4;
            btnGeneratePieChart.Text = "Generate Pie Chart";
            btnGeneratePieChart.UseVisualStyleBackColor = true;
            btnGeneratePieChart.Click += btnGeneratePieChart_Click;
            // 
            // pieChartPanel
            // 
            pieChartPanel.Location = new Point(23, 163);
            pieChartPanel.Name = "pieChartPanel";
            pieChartPanel.Size = new Size(240, 221);
            pieChartPanel.TabIndex = 5;
            pieChartPanel.Paint += pieChartPanel_Paint;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(251, 107);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(85, 32);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnReset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 431);
            Controls.Add(btnReset);
            Controls.Add(pieChartPanel);
            Controls.Add(btnGeneratePieChart);
            Controls.Add(txtValuesList);
            Controls.Add(label1);
            Controls.Add(txtLabelList);
            Controls.Add(lblList);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblList;
        private TextBox txtLabelList;
        private TextBox txtValuesList;
        private Label label1;
        private Button btnGeneratePieChart;
        private Panel pieChartPanel;
        private Button btnReset;
    }
}
