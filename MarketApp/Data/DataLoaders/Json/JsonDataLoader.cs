using Newtonsoft.Json;
using MarketApp.Interfaces;
using MarketApp.Data.DataLoader.Maps;

namespace MarketApp.Data.DataLoader
{
    public class JsonDataLoader:IDataLoader
    {
        public List<Product> LoadData(string datasetPath)
        {
            using StreamReader reader = new StreamReader(datasetPath);
            var json = reader.ReadToEnd();
            List<JsonProductMap>? jsonProducts = JsonConvert.DeserializeObject<List<JsonProductMap>>(json);
            List<Product> products = jsonProducts.Select(p => new Product
            {
                Brand = p.Brand != null ? p.Brand : " ",
                Title = p.Title,
                Dec2021Price = p.Dec2021Price,
                Jul2022Price = p.Jul2022Price,
                May2022Price = p.May2022Price,
                Sep2022Price = p.Sep2022Price,
                Oct2022Price = p.Oct2022Price,

            }).ToList();

            return products;
        }
    }
}