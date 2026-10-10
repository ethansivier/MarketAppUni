namespace MarketApp.Interfaces
{
    public interface IProduct
    {
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Dec2021Price {get;set;}
        public string May2022Price {get;set;}
        public string Jul2022Price {get;set;}
        public string Sep2022Price {get;set;}
        public string Oct2022Price {get;set;}
    }
}