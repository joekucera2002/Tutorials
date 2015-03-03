using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public class Product
    {
        private string _name;
        
        public Int32 ProductId { get; set; }

        public String Name
        {
            get { return String.Format("{0}: {1}", ProductId, _name); }
            set { _name = value; }
        }

        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String Category { get; set; }
    }
}