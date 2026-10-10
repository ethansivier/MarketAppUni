using MarketDataAnalyser.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarketApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Product> _products;

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("form1 loaded");
            CustomizeGridAppearance();
            _products =  CsvDataLoader.LoadData();
            RefreshGrid();
            ConfigureChart();
        }

        private void CustomizeGridAppearance()
        { 
            Console.WriteLine("customizing grid appearance");
            ProductGrid.AutoGenerateColumns = false;
            ProductGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ProductGrid.RowHeadersVisible = false;
            ProductGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewTextBoxColumn titleCol = new DataGridViewTextBoxColumn();
            titleCol.HeaderText = "Title";
            titleCol.DataPropertyName = "Title";


            DataGridViewTextBoxColumn brandCol = new DataGridViewTextBoxColumn();
            brandCol.HeaderText = "Brand";
            brandCol.DataPropertyName = "Brand";
            
            ProductGrid.Columns.Add(titleCol);
            ProductGrid.Columns.Add(brandCol);
        }

        private void RefreshGrid()
        {
            List<Product> searchResult = _products.Where(p => p.Brand.ToLower().Contains(SearchText.Text.ToLower())).ToList();
            ProductGrid.DataSource = searchResult;
        }
    
        
        private void RefreshChart(Product selectedProduct)
        {
            PricesChart.Series["Price"].Points.Clear();
            List<String> validPoints = new List<String> {"Dec2021Price", "May2022Price", "Jul2022Price", "Sep2022Price", "Oct2022Price"};

            foreach (String point in validPoints)
            {
                String value = selectedProduct.GetType().GetProperty(point).GetValue(selectedProduct, null).ToString();
                Decimal? price = Calculations.ConvertToDecimal(value);
                if (price != null)
                {
                    int index = PricesChart.Series["Price"].Points.AddY(price);
                    DataPoint datapoint = PricesChart.Series["Price"].Points[index];
                    datapoint.AxisLabel = point.Replace("Price", "").Insert(3, " ");
                    datapoint.XValue = PricesChart.Series["Price"].Points.Count;
                }

                
            }

            foreach (DataPoint point in PricesChart.Series["Price"].Points)
            {
                point.Label = point.YValues[0].ToString();
            }
         
        }

        private void ConfigureChart()
        {
            PricesChart.Series.Clear();
            PricesChart.ChartAreas.Clear();
            PricesChart.ChartAreas.Add(new ChartArea());
            PricesChart.Series.Add(new Series("Price")  
            {
                ChartType = SeriesChartType.Area
            });
        }


        private async void SearchText_TextChanged(object sender, System.EventArgs e)
        {
            int beforePause = SearchText.Text.Length;

            await Task.Delay(300);

            if (SearchText.Text.Length == beforePause)
            {
                RefreshGrid();
            }
        }


        private void ProductGrid_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            Console.WriteLine("clicked");
            Product selectedProduct = (Product)ProductGrid.Rows[e.RowIndex].DataBoundItem;
            RefreshChart(selectedProduct);
        }

        private void CalculateChangeButton_Click(object sender, System.EventArgs e)
        {
            var selectedRows = ProductGrid.SelectedRows;
            if (selectedRows.Count <= 0)
            {
                return;
            }
            List<Product> selectedProducts = new List<Product>();
            foreach (DataGridViewRow row in selectedRows)
            {
                selectedProducts.Add((Product)row.DataBoundItem);
            }

            string message = Calculations.CalculateChangeInPrice(selectedProducts);
            MessageBox.Show(message);
        }

    }
}
