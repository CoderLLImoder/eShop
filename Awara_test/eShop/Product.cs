public class Product : AbstractProduct
{
    public override int Articul { get; set; }
    public override string Name { get; set; }
    public override decimal Price { get; set; }
    
    public override string ToString()
    {
        return $"Арт.{Articul} - {Name} - {Price:C}";
    }
}
