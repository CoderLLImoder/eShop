public class CartItem
{
    public required IProduct Product { get; set; }
    public required int Quantity { get; set; }

    public decimal Total => Product.Price * Quantity;
    
    public override string ToString()
    {
        return $"Арт.{Product.Articul} - {Product.Name} x {Quantity} = {Total:C}";
    }
}
