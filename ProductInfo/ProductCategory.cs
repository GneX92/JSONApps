namespace ProductInfo
{
    internal class ProductCategory
    {
        public string? CategoryName { get; set; }
        public List<Product>? Products { get; set; }

        public override string ToString() => CategoryName is not null ? CategoryName : "Unknown CategoryName";
    }
}