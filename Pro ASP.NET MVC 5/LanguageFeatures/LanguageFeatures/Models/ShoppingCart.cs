using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public class ShoppingCart : IEnumerable<Product>
    {
        public List<Product> Products { get; set; }

        #region IEnumerable<Product> Members

        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}