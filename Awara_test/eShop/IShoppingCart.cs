public interface IShoppingCart
{
    void AddItem(IProduct product, int quantity);
    void RemoveItem(int productId, int quantity);
    void ShowCart();
}
