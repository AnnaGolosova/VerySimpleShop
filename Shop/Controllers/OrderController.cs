using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (DBContext _context = new DBContext())
            {
                var orders = _context.Order
                    .Select(o => new OrderExtended()
                    {
                        OrderName = o.Name,
                        Address = o.Address,
                        DeviceId = o.DeviceId,
                        Id = o.Id
                    })
                    .ToList();

                orders.ForEach(o =>
                {
                    var device = _context.Device.Find(o.DeviceId);
                    o.Company = device.Company;
                    o.Price = device.Price;
                    o.Year = device.Year;
                    o.DeviceName = device.Name;
                });
                
                return View(orders);
            }
        }

        [HttpGet]
        public ActionResult Add(int deviceId)
        {
            try
            {
                using (DBContext _context = new DBContext())
                {
                    ViewBag.Device = _context.Device.Find(deviceId);

                    return View();
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home", new { errorMessage = "Товар не может быть найден" });
            }
        }

        [HttpPost]
        public ActionResult Add(Order order)
        {
            try
            {
                using (DBContext _context = new DBContext())
                {
                    _context.Order.Add(order);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home", new { successMessage = "Заказ успешно добавлен. Для просмотра выберите пункт меню 'Заказы'" });
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home", new { errorMessage = "Товар не может быть добавлен по причине "});
            }
        }
    }
}