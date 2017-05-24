using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Threading.Models
{
    public class Order
    {
        public string loginname { set; get; }

        public string username { set; get; }
    }

    public class OrderResult
    {
        public bool result { set; get; }
        public string content { set; get; }
    }
}