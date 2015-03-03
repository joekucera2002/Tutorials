using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}