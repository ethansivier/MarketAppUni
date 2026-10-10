using MarketDataAnalyser.Data;

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
            _products =  CsvDataLoader.LoadData();
            ProductGrid.DataSource = _products;

        }

        private void CustomizeGridAppearance()
        {
            ProductGrid.AutoGenerateColumns = false;
            ProductGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn titleCol = new DataGridViewTextBoxColumn();
            titleCol.HeaderText = "Title";
            titleCol.DataPropertyName = "Title";
            ProductGrid.Columns.Add(titleCol);
        }
    }
}
