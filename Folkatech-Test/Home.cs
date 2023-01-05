using Folkatech_Test.ControllerWebAPI;
using Folkatech_Test.DummyRepository;
using Folkatech_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folkatech_Test
{
    public class Home
    {
        public Home()
        {
            Menu();
        }

        public void Menu()
        {
            Console.Clear();

            Console.WriteLine("Please select your API by entering a number.");
            Console.WriteLine("1. Show All Category");
            Console.WriteLine("2. Show Products");
            Console.WriteLine("3. Create New Category");
            Console.WriteLine("4. Create New Products");
            Console.WriteLine("5. Exit");
            Console.Write("Select a number : ");

            string? numberSelected = Console.ReadLine();

            if(numberSelected == "1")
            {
                WebAPI controllerWebAPI = new WebAPI();
                var result = controllerWebAPI.ShowAllCategory();

                Console.WriteLine("{0,20}{1,40}", "Category", "Filter");

                foreach (var category in result)
                {
                    Console.WriteLine("{0,20}{1,40}", category.Category, category.Filter);

                }

                BackToMenu();

            }
            if(numberSelected == "2")
            {
                WebAPI controllerWebAPI = new WebAPI();
                var result = controllerWebAPI.ShowProducts();

                if(result.Count() > 0)
                {
                    Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,20}", "SKU", "Category", "Name", "Description", "Price");

                    foreach (var category in result)
                    {
                        Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,20:C}", category.SKU, category.CategoryName, category.Name, category.Description, category.Price);
                    }

                    BackToMenu();

                }
                else
                {
                    Console.WriteLine("Products not found for Category selected");

                    BackToMenu();

                }

            }
            if (numberSelected == "3")
            {
                WebAPI controllerWebAPI = new WebAPI();
                var result = controllerWebAPI.CreateCategory();
                Console.WriteLine(result);
                BackToMenu();

            }
            if (numberSelected == "4")
            {
                WebAPI controllerWebAPI = new WebAPI();

                ProductModel input = new ProductModel();

                var categoryList = CategoryRepository.categoryModels;
                var products = ProductRepository.productModel;

                Console.WriteLine("Id\t Category");

                foreach (var category in categoryList)
                {
                    Console.WriteLine($"{category.Id}\t {category.Category}");
                }

                Console.Write("Please select category number : ");

                input.CategoryId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please input product name : ");
                input.Name = Console.ReadLine();


                Console.Write("Please input description : ");
                input.Description = Console.ReadLine();

                Console.Write("Please input price (in IDR) : ");
                input.Price = Convert.ToDecimal(Console.ReadLine());


                var result = controllerWebAPI.CreateProduct(input);
                Console.WriteLine(result);
                BackToMenu();

            }
            if (numberSelected == "5")
            {
                Environment.Exit(0);
            }


                Console.WriteLine("Please select a number on the list");
            Menu();       
        }

        public void BackToMenu()
        {
            Console.WriteLine("Press anything to go to menu");

            Console.ReadKey();

            Console.WriteLine();

            Menu();
        }

    }
}
