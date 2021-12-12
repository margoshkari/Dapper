using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Product
    {
        public int product_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int category_id { get; set; }
        public int manufacturer_id { get; set; }
        public Product()
        {

        }
    }
}
