using Folkatech_Test.DummyRepository;
using Folkatech_Test.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Folkatech_Test.Services
{
    public class Service
    {
        public async Task<List<CategoryModel>> ShowAllCategory()
        {
            //INPUT YOUR API URL
            var url = "https://localhost:7149/api/FolkaShop/showAllCategory";
            var client = new HttpClient();
            var result = new List<CategoryModel>();

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                var message = await client.SendAsync(request);
                var hhtpResult = await message.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<CategoryModel>>(hhtpResult);

                return result;

            }
        }

        public async Task<List<ProductModel>> ShowProducts()
        {
            Console.Clear();

            //INPUT YOUR API URL
            var url = "https://localhost:7149/api/FolkaShop/showAllCategory";
            var client = new HttpClient();
            var result = new List<CategoryModel>();

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                var message = await client.SendAsync(request);
                var hhtpResult = await message.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<CategoryModel>>(hhtpResult);

            }

            Console.WriteLine("Id\t Category");

            foreach (var category in result)
            {
                Console.WriteLine($"{category.Id}\t {category.CategoryName}");
            }

            Console.Write("Please select category number :");

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            return await SelectCategory(selectedNumber);
        }

        public async Task<List<ProductModel>> SelectCategory(int id)
        {
            //INPUT YOUR API URL
            var url = $"https://localhost:7149/api/FolkaShop/showProducts?id={id}";
            var client = new HttpClient();
            var result = new List<ProductModel>();

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {

                var message = await client.SendAsync(request);
                var hhtpResult = await message.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<ProductModel>>(hhtpResult);

            }

            return result;
        }



        public async Task<string> CreateCategory()
        {

            Console.Write("Please input your category name : ");
            var CategoryName = Console.ReadLine();

            //INPUT YOUR API URL
            var url = $"https://localhost:7149/api/FolkaShop/createCategory?categoryName={CategoryName}";
            var client = new HttpClient();

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                var message = await client.SendAsync(request);
                return "Category has been created!";
            }

        }

        public async Task<string> CreateProduct(ProductModel newProduct)
        {
            //INPUT YOUR API URL
            var url = $"https://localhost:7149/api/FolkaShop/createProduct";
            var client = new HttpClient();


            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                var json = JsonConvert.SerializeObject(newProduct);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    var message = await client.SendAsync(request);
                    var hhtpResult = await message.Content.ReadAsStringAsync();

                    return "Product has been created!";

                }

            }

        }

    }
}
