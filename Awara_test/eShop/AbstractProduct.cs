public abstract class AbstractProduct : IProduct
{
    public abstract int Articul { get; set; }
    public abstract string Name { get; set; }
    public abstract decimal Price { get; set; }
    
    public virtual string GetDescription()
    {
        return $"{Name} стоит {Price:C}";
    }
}
