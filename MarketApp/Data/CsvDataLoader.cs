using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MarketDataAnalyser.Data
{
   public static class CsvDataLoader
    {
        private static string datasetPath = Path.Combine(Application.StartupPath.Replace(@"\bin\Debug\net9.0-windows", ""), "Data\\AmazonDataset.csv"); // replace due to startuppath resolving to bin\debug\net9.0-wdinwso causing crashes
        private const int dataLimit = 100000;

        public static List<Product> LoadData()
        {
            using (var reader = new StreamReader(datasetPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) 
            {
                csv.Context.RegisterClassMap<ProductMap>();
                List<Product> products = csv.GetRecords<Product>().Take(dataLimit).ToList();

                return products;
            }
        }
    }
}
