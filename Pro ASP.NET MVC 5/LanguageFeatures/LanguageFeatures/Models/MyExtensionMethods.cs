using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static Decimal TotalPrices(this ShoppingCart cartParam)
        {
            Decimal total = 0;

            foreach (Product prod in cartParam.Products)
            {
                total += prod.Price;
            }

            return total;
        }

        public static Decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach (Product prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }

        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum, String categoryParam)
        {
            foreach (Product prod in productEnum)
            {
                if (prod.Category == categoryParam)
                {
                    yield return prod;
                }
            }
        }
    }
}