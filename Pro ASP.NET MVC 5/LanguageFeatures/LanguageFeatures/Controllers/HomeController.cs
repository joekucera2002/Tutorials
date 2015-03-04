using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View();
        }

        // GET: Home/AutoProperty
        public ViewResult AutoProperty()
        {
            // Create a new Product object
            Product myProduct = new Product();

            // Set the property value
            myProduct.ProductId = 1;
            myProduct.Name = "Kayak";

            // Get the property
            String productName = myProduct.Name;

            // Generate the view
            return View("Result", (Object)String.Format("ProductName: {0}", productName));
        }

        // GET: Home/CreateProduct
        public ViewResult CreateProduct()
        {
            // Create and populate a new Product object
            Product myProduct = new Product
            {
                ProductId = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            return View("Result", (Object)String.Format("Category: {0}", myProduct.Category));
        }

        // GET: Home/CreateCollection
        public ViewResult CreateCollection()
        {
            String[] stringArray = {"apple", "orange", "plum"};

            List<Int32> intList = new List<Int32> {10, 20, 30, 40};

            Dictionary<String, Int32> myDict = new Dictionary<string, Int32>
            {
                {"apple", 10},
                {"orange", 20},
                {"plum", 30}
            };

            return View("Result", (Object)stringArray[1]);
        }

        // GET: Home/UseExtension
        public ViewResult UseExtension()
        {
            // Create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // Get the total value of the products in the cart
            Decimal cartTotal = cart.TotalPrices();

            return View("Result", (Object)String.Format("Total: {0:c}", cartTotal));
        }

        // GET: Home/UseExtensionEnumerable
        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // Create and populate an array of Product objects
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            // Get the total value of the products in the cart
            Decimal cartTotal = products.TotalPrices();
            Decimal arrayTotal = productArray.TotalPrices();

            return View("Result", (Object)String.Format("Cart total: {0}, Array Total: {1}", cartTotal, arrayTotal));
        }

        // GET: Home/UseFilterExtensionMethod
        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "Kayak", 
                        Category = "Watersports", 
                        Price = 275M
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Category = "Watersports",
                        Price = 48.95M
                    },
                    new Product
                    {
                        Name = "Soccer ball",
                        Category = "Soccer",
                        Price = 19.50M
                    },
                    new Product
                    {
                        Name = "Corner flag",
                        Category = "Soccer",
                        Price = 34.95M
                    }
                }
            };

            Decimal total = 0;

            foreach (Product prod in products.Filter((prod) => prod.Category == "Soccer" || prod.Price > 20))
            {
                total += prod.Price;
            }

            return View("Result", (Object) String.Format("Total: {0}", total));
        }

        // GET: Home/CreateAnonArray
        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new
                {
                    Name = "MVC",
                    Category = "Pattern"
                },
                new
                {
                    Name = "Hat",
                    Category = "Clothing"
                },
                new
                {
                    Name = "Apple",
                    Category = "Fruit"
                }
            };

            StringBuilder result = new StringBuilder();

            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }

            return View("Result", (Object) result.ToString());
        }

        // GET: Home/FindProducts
        public ViewResult FindProducts()
        {
            Product[] products =
            {
                new Product
                {
                    Name = "Kayak",
                    Category = "Watersports",
                    Price = 275M
                },
                new Product
                {
                    Name = "Lifejacket",
                    Category = "Watersports",
                    Price = 48.95M
                },
                new Product
                {
                    Name = "Soccer Ball",
                    Category = "Soccer",
                    Price = 19.50M
                },
                new Product
                {
                    Name = "Corner Flag",
                    Category = "Soccer",
                    Price = 34.95M
                }
            };

            var foundProducts =
                products.OrderByDescending(e => e.Price)
                    .Take(3)
                    .Select(e => 
                        new
                        {
                            e.Name, 
                            e.Price
                        });

            // Create the result
            StringBuilder result = new StringBuilder();

            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0}", p.Price);
            }

            return View("Result", (Object) result.ToString());
        }
    }
}