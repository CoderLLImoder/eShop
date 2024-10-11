using System.Collections.Generic;

public class ShoppingCart : IShoppingCart
{
    private List<CartItem> items = new List<CartItem>();

    public void AddItem(IProduct product, int quantity)
    {
        var cartItem = items.Find(item => item.Product.Articul == product.Articul);
        if (cartItem != null)
        {
            cartItem.Quantity += quantity;
        }
        else
        {
            items.Add(new CartItem { Product = product, Quantity = quantity });
        }
    }

    public void RemoveItem(int productArticul, int quantity)
    {
        var item = GetItemByArticul(productArticul);
        if (item != null)
        {
            if (quantity < item.Quantity)
                item.Quantity -= quantity;
            else
                items.RemoveAll(item => item.Product.Articul == productArticul);
        }
    }

    public void ShowCart()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Корзина пуста.");
        }
        else
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Итого: {items.Sum(item => item.Total):C}");
        }
    }

    public CartItem GetItemByArticul(int productArticul)
    {
        return items.Where(x => x.Product.Articul == productArticul).FirstOrDefault();
    }
}
