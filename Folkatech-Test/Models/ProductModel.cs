using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folkatech_Test.Models
{
    public class ProductModel
    {
        public int SKU { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

    }
}
