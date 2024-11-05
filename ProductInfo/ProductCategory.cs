namespace ProductInfo
{
    internal class ProductCategory
    {
        public string? CategoryName { get; set; }
        public List<Product>? Products { get; set; }

        public override string ToString() => CategoryName ?? "Unknown CategoryName";
    }
}