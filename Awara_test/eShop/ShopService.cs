using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class ShopService
{
    private List<Product> Products { get; set; }

    public ShopService()
    {
        Products = new List<Product>();
    }

    public void LoadProductsFromFile(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            Products = JsonConvert.DeserializeObject<List<Product>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
        }
    }

    public void ShowProducts()
    {
        Console.WriteLine("Список товаров:");
        foreach (var product in Products)
        {
            Console.WriteLine(product);
        }
    }

    public IProduct GetProductByArticul(int articul)
    {
        return Products.FirstOrDefault(p => p.Articul == articul);
    }
}
