using MarketApp.Interfaces;
using Newtonsoft.Json;

namespace MarketApp.Data.DataLoader.Maps
{
    public class  JsonProductMap:IProduct
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("dec-2021-price")]
        public string Dec2021Price {get;set;}
        [JsonProperty("may-2022-price")]
        public string May2022Price {get;set;}
        [JsonProperty("jul-2022-price")]
        public string Jul2022Price {get;set;}
        [JsonProperty("sep-2022-price")]
        public string Sep2022Price {get;set;}
        [JsonProperty("oct-2022-price")]
        public string Oct2022Price {get;set;}
    }
}