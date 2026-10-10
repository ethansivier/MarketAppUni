using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace MarketDataAnalyser.Data
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Map(p => p.Title).Name("title");
            Map(p => p.Brand).Name("brand");
            Map(p => p.Rating).Name("rating");
            Map(p => p.InitialPrice).Name("initial_price");
            Map(p => p.Currency).Name("currency");
            Map(p => p.Categories).Name("categories");
            Map(p => p.DateFirstAvaliable).Name("date_first_available");

        }
    }

}
