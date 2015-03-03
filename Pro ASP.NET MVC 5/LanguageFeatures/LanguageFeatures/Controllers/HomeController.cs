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
            return View("Result", (object)String.Format("ProductName: {0}", productName));
        }
    }
}