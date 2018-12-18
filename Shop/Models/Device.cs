using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Year { get; set; }
        public float Price { get; set; }
    }
}