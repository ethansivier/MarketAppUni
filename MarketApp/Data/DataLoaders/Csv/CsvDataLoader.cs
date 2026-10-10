using CsvHelper;
using System.Globalization;
using MarketApp.Interfaces;
using MarketApp.Data.DataLoader.Maps;

namespace MarketApp.Data.DataLoader
{
    public class CsvDataLoader:IDataLoader
    {
        private const int dataLimit = 100000;

        public List<Product> LoadData(string datasetPath)
        {
            using (var reader = new StreamReader(datasetPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) 
            {
                csv.Context.RegisterClassMap<CsvProductMap>();
                List<Product> products = csv.GetRecords<Product>().Take(dataLimit).ToList();

                return products;
            }
        }
    }
}
