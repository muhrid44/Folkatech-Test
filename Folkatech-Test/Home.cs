using Folkatech_Test.ControllerWebAPI;
using Folkatech_Test.DummyRepository;
using Folkatech_Test.Models;
using Folkatech_Test.Services;
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
        }

        public async Task Menu()
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
                Service controllerWebAPI = new Service();

                var result = await controllerWebAPI.ShowAllCategory();

                Console.WriteLine("{0,20}{1,40}", "Category", "Filter");

                foreach (var category in result)
                {
                    Console.WriteLine("{0,20}{1,40}", category.CategoryName, category.Filter);

                }

                BackToMenu();

            }
            if(numberSelected == "2")
            {
                Service controllerWebAPI = new Service();

                var result = await controllerWebAPI.ShowProducts();

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
                Service controllerWebAPI = new Service();
                var result = await controllerWebAPI.CreateCategory();
                Console.WriteLine(result);
                BackToMenu();

            }
            if (numberSelected == "4")
            {
                Service controllerWebAPI = new Service();

                ProductModel productModel = new ProductModel();

                Console.Write("Please select category number : ");

                productModel.CategoryId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please input product name : ");
                productModel.Name = Console.ReadLine();


                Console.Write("Please input description : ");
                productModel.Description = Console.ReadLine();

                Console.Write("Please input price (in IDR) : ");
                productModel.Price = Convert.ToDecimal(Console.ReadLine());


                var result = await controllerWebAPI.CreateProduct(productModel);

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

            Menu().Wait();
        }

    }
}
