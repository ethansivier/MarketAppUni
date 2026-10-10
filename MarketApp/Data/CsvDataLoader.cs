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
        private static string datasetPath = "C:\\Users\\ethan\\source\\repos\\MarketApp\\MarketApp\\Data\\AmazonProducts.csv";
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
