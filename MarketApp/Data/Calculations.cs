using System.Globalization;
using MarketDataAnalyser.Data;

namespace MarketDataAnalyser.Data
{
    public static class Calculations
    {

        public static decimal? GetPrice(List<String> properties, Product product)
        {
            foreach(String prop in properties)
            {
                String value = product.GetType().GetProperty(prop).GetValue(product, null).ToString();
                if (value != null)
                {
                    decimal? price = ConvertToDecimal(value);
                    if (price == null) continue;
                    return price;
                }
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
        
        public static List<String> ReverseList(List<String> list)
        {
            list.Reverse();
            return list;
        }

        public static string CalculateChangeInPrice(List<Product> selectedProducts)
        {
            decimal totalFirst = 0;
            decimal totalLast = 0;
            decimal change = 0;
            List<String> properties = new List<String> {"Dec2021Price", "May2022Price", "Jul2022Price", "Sep2022Price", "Oct2022Price"};

            foreach (Product product in selectedProducts)
            {
                decimal? productFirst = GetPrice(properties, product);
                decimal? productLast = GetPrice(ReverseList(properties), product);

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