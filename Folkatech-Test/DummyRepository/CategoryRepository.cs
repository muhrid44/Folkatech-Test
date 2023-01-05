using Folkatech_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folkatech_Test.DummyRepository
{
    public static class CategoryRepository
    {
        public static List<CategoryModel> categoryModels = new List<CategoryModel>()
        {
            new CategoryModel() { Id = 1, Category = "Home", Filter = "All SKU’s in the range 1xxxx" },
            new CategoryModel() { Id = 2, Category = "Garden", Filter = "All SKU’s in the range 2xxxx" },
            new CategoryModel() { Id = 3, Category = "Electronics", Filter = "All SKU’s in the range 3xxxx" },
            new CategoryModel() { Id = 4, Category = "Fitness", Filter = "All SKU’s in the range 4xxxx" },
            new CategoryModel() { Id = 5, Category = "Toys", Filter = "All SKU’s in the range 5xxxx" }
        };
    }
}
