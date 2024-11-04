using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInfo
{
    internal class ProductCategory
    {
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

        public override string ToString() => CategoryName;
    }
}