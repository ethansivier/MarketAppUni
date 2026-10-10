using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAnalyser.Data
{
   public class Product
    {
        public string Title { get; set; }
        public string Brand { get; set; }
        public string InitialPrice { get; set; }
        public string Currency {  get; set; }
        public string Categories { get; set; }
        public string DateFirstAvaliable { get; set; }
        public string Rating { get; set; }
    }
}
