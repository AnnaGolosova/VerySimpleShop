using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class DBContext : DbContext
    {
        //Указываем имя строки подключения к базе из файла Web.config
        public DBContext() : base("ForStegor") { }

        //Описываем наборы данные, т.е. существующие таблицы
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Order> Order { get; set; }
    }
}