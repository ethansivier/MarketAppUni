namespace MarketApp
{
    public partial class Form1 : System.Windows.Forms.Form
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea one= new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend two = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series three = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ProductGrid = new System.Windows.Forms.DataGridView();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.CalculateChangeButton = new System.Windows.Forms.Button();
            this.PricesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PricesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductGrid
            // 
            this.ProductGrid.Location = new System.Drawing.Point(21, 58);
            this.ProductGrid.Name = "ProductGrid";
            this.ProductGrid.Size = new System.Drawing.Size(311, 345);
            this.ProductGrid.TabIndex = 1;
            this.ProductGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductGrid_CellDoubleClick);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(21, 14);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(310, 20);
            this.SearchText.TabIndex = 1;
            this.SearchText.TextChanged += new System.EventHandler(this.SearchText_TextChanged);
            // 
            // CalculateChangeButton
            // 
            this.CalculateChangeButton.Location = new System.Drawing.Point(34, 410);
            this.CalculateChangeButton.Name = "CalculateChangeButton";
            this.CalculateChangeButton.Size = new System.Drawing.Size(236, 28);
            this.CalculateChangeButton.TabIndex = 2;
            this.CalculateChangeButton.Tag = "";
            this.CalculateChangeButton.Text = "Calculate Change";
            this.CalculateChangeButton.UseVisualStyleBackColor = true;
            this.CalculateChangeButton.Click += new System.EventHandler(this.CalculateChangeButton_Click);
            // 
            // PricesChart
            // 
            one.Name = "ChartArea1";
            this.PricesChart.ChartAreas.Add(one);
            two.Name = "Legend1";
            this.PricesChart.Legends.Add(two);
            this.PricesChart.Location = new System.Drawing.Point(369, 58);
            this.PricesChart.Name = "PricesChart";
            three.ChartArea = "ChartArea1";
            three.Legend = "Legend1";
            three.Name = "Series1";
            this.PricesChart.Series.Add(three);
            this.PricesChart.Size = new System.Drawing.Size(386, 345);
            this.PricesChart.TabIndex = 3;
            this.PricesChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(767, 442);
            this.Controls.Add(this.PricesChart);
            this.Controls.Add(this.CalculateChangeButton);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.ProductGrid);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PricesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView ProductGrid;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button CalculateChangeButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart PricesChart;
    }
}