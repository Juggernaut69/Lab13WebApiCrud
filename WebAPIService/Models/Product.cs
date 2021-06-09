using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIService.Models
{
    public class Product
    {
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public Nullable<int> Quantity { set; get; }
        public Nullable<int> Price { set; get; }
    }
}