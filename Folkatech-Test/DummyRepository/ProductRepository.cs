using Folkatech_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folkatech_Test.DummyRepository
{
    public static class ProductRepository
    {
        public static List<ProductModel>? productModel = new List<ProductModel>()
        {
            new ProductModel(){SKU = "10001", CategoryId = 1, CategoryName= "Home",  Name = "Chair", Description = "A Charming Chair", Price = 150000},
            new ProductModel(){SKU = "10002", CategoryId = 1, CategoryName= "Home",  Name = "Lamp", Description = "A Birght Lamp", Price = 50000},
            new ProductModel(){SKU = "20001", CategoryId = 2, CategoryName= "Garden",  Name = "Picnic Table", Description = "A Table for Picnic", Price = 2000000}
        };
    }
}
