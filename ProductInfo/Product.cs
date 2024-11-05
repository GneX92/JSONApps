namespace ProductInfo
{
    internal class Product
    {
        public string? Name { get; set; }
        public double Price { get; set; }

        public override string ToString() => Name is not null ? Name : "Unknown Productname";
    }
}