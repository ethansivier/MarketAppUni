using System.Globalization;
using MarketApp.Data;

namespace MarketApp.Data
{
    public static class Calculations
    {

        public static decimal? GetPrice(List<string> properties, Product product)
        {
            foreach(string prop in properties)
            {
                object? rawValue = product[prop];
                if (rawValue == null) continue;
                
                decimal? price = ConvertToDecimal(rawValue.ToString());
                if (price == null) continue;
                return price;
            }
            return null;
        }

        public static decimal? ConvertToDecimal(string priceString)
        {
            if (decimal.TryParse(priceString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                return price;
            return null;
        }

        public static decimal CalculatePercentageChange(decimal? totalFirst, decimal? totalLast)
        {
            if (totalFirst.HasValue && totalLast.HasValue && totalFirst.Value > 0)
            {
                decimal change = (totalLast.Value - totalFirst.Value) / totalFirst.Value * 100;
                return change;
            }
            return 0;
        }
        
        public static List<string> ReverseList(List<string> list)
        {
            List<string> reversedList = new List<string>(list);
            reversedList.Reverse();
            return reversedList;
        }

        public static string CalculateChangeInPrice(List<Product> selectedProducts)
        {
            decimal totalFirst = 0;
            decimal totalLast = 0;
            decimal change = 0;

            List<string> properties = new List<string> {"Dec2021Price", "May2022Price", "Jul2022Price", "Sep2022Price", "Oct2022Price"};
            List<string> reversedProperties = ReverseList(properties);

            foreach (Product product in selectedProducts)
            {
                decimal? productFirst = GetPrice(properties, product); //encapsulating what varies & dry
                decimal? productLast = GetPrice(reversedProperties, product); 

                if (productFirst.HasValue && productLast.HasValue)
                {
                    totalFirst += productFirst.Value;
                    totalLast += productLast.Value;
                }
            }
            change = CalculatePercentageChange(totalFirst, totalLast);

            if (change != 0)
            {
                return $"Price {(change > 0 ? "increased" : "decreased")} by {Math.Floor(change * 10) / 10}%";
            }
            return "Price did not change";
        }
    }
}