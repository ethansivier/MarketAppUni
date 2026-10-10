using MarketApp.Data;

namespace MarketApp.Interfaces
{
    public interface IDataLoader
    {
        List<Product> LoadData(string datasetPath);
    }
}