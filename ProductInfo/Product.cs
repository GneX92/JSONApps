namespace ProductInfo
{
    internal class Product
    {
        public string? Name { get; set; }
        public double Price { get; set; }

        public override string ToString() => Name ?? "Unknown Productname";
    }
}