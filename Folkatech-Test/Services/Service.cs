using Folkatech_Test.DummyRepository;
using Folkatech_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folkatech_Test.Services
{
    public class Service
    {
        public List<CategoryModel> ShowAllCategory()
        {
            return CategoryRepository.categoryModels;
        }

        public List<ProductModel> ShowProducts()
        {
            Console.Clear();

            var categoryList = CategoryRepository.categoryModels;
            var products = ProductRepository.productModel;

            Console.WriteLine("Id\t Category");

            foreach (var category in categoryList)
            {
                Console.WriteLine($"{category.Id}\t {category.Category}");
            }

            Console.Write("Please select category number :");

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            var productSelected = products.Where(product => product.CategoryId == selectedNumber).ToList();

            return productSelected;
        }
        
        public string CreateCategory()
        {
            CategoryModel newCategory = new CategoryModel();

            var categoryList = CategoryRepository.categoryModels;

            var latestCategory = categoryList.OrderByDescending(category => category.Id).First();

            int newId = latestCategory.Id + 1;

            newCategory.Id = newId;

            Console.Write("Please input your category : ");
            newCategory.Category = Console.ReadLine();

            newCategory.Filter = $"All SKU’s in the range {newId}xxxx";

            categoryList.Add(newCategory);

            return "Category has been created!";

        }

        public string CreateProduct(ProductModel newProduct)
        {
            var categoryList = CategoryRepository.categoryModels;
            var products = ProductRepository.productModel;

            var isCategoryAvailable = categoryList.Select(x => x.Id == newProduct.CategoryId).ToList();

            if (isCategoryAvailable.Count == 0)
            {
                return "Category Not Available";
            }

            var productInCategoryCheck = products.Where(x => x.CategoryId == newProduct.CategoryId).ToList();

            if(productInCategoryCheck.Count() == 0)
            {
                var categoryIdLength = newProduct.CategoryId.ToString().Length;
                var newProductSKU = "1".PadLeft(5 - categoryIdLength, '0');
                var newSKU = newProduct.CategoryId.ToString() + newProductSKU;

                newProduct.SKU = newSKU;

                var newCategoryName = categoryList.Where(x => x.Id == newProduct.CategoryId).Single();

                newProduct.CategoryName = newCategoryName.Category;

                products.Add(newProduct);
                return "Product has been Created!";
            }

            var productInCategory = products.OrderByDescending(x => Convert.ToInt32(x.SKU)).Where(x => x.CategoryId == newProduct.CategoryId).First();

            var categoryName = categoryList.Where(x => x.Id == newProduct.CategoryId).Single();

            newProduct.CategoryName = categoryName.Category;

            var latestSKU = Convert.ToInt32(productInCategory.SKU) + 1;

            newProduct.SKU = latestSKU.ToString();

            products.Add(newProduct);

            return "Product has been Created!";

        }

    }
}
