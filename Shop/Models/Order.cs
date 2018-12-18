using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}