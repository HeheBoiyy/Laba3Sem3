namespace WinFormsApp
{
    partial class DistributionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartSpeciality = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chartSpeciality).BeginInit();
            SuspendLayout();
            // 
            // chartSpeciality
            // 
            chartSpeciality.BackColor = Color.DarkOrange;
            chartSpeciality.BorderlineColor = Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            chartSpeciality.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartSpeciality.Legends.Add(legend1);
            chartSpeciality.Location = new Point(18, 15);
            chartSpeciality.Name = "chartSpeciality";
            chartSpeciality.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartSpeciality.Series.Add(series1);
            chartSpeciality.Size = new Size(765, 410);
            chartSpeciality.TabIndex = 0;
            chartSpeciality.Text = "chart1";
            // 
            // DistributionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOrange;
            ClientSize = new Size(800, 450);
            Controls.Add(chartSpeciality);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DistributionForm";
            Text = "Гистаграмма студентов";
            ((System.ComponentModel.ISupportInitialize)chartSpeciality).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpeciality;
    }
}