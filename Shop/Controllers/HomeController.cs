using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string successMessage = null, string errorMessage = null)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            using (DBContext _context = new DBContext())
            {
                var devices = _context.Device.ToList();

                return View(devices);
            }
        }

        [HttpGet]
        public ActionResult DeviceDetails(int deviceId)
        {
            try
            {
                using (DBContext _context = new DBContext())
                {
                    var device = _context.Device.Find(deviceId);

                    return View(device);
                }

            }
            catch
            {
                ViewBag.ErrorMessage = "Не удалось найти товар";

                return View();
            }
        }

        [HttpPost]
        public ActionResult DeviceDetails(Device item)
        {
            try
            {
                using (DBContext _context = new DBContext())
                {
                    var oldItem  = _context.Device.Find(item.Id);

                    oldItem.Name = item.Name;
                    oldItem.Price = item.Price;
                    oldItem.Year = item.Year;
                    oldItem.Company = item.Company;

                    _context.SaveChanges();

                    return RedirectToAction("Index", new { successMessage = "Товар отредактирован!"});
                }

            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "Не удалось обновить товар по  причине - " + ex.Message;

                return View(item);
            }
        }


        [HttpGet]
        public ActionResult CreateDevice()
        {
            return View(new Device());
        }


        [HttpPost]
        public ActionResult CreateDevice(Device device)
        {
            try
            {
                using (DBContext _context = new DBContext())
                {
                    _context.Device.Add(device);

                    _context.SaveChanges();

                    return RedirectToAction("Index", new { successMessage = "Товар добавлен!" });
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Не удалось добавить товар по  причине - " + ex.Message;

                return View(device);
            }
        }

        [HttpGet]
        public ActionResult DeleteDevice(int deviceId)
        {
            try
            {
                using (DBContext _context = new DBContext())
                {
                   var device = _context.Device.Find(deviceId);

                    List<Order> orders = _context.Order.Where(o => o.DeviceId == device.Id).ToList();
                    _context.Order.RemoveRange(orders);

                    _context.Device.Remove(device);
                    _context.SaveChanges();

                    return RedirectToAction("Index", new { successMessage = "Товар удален!" });
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { errorMessage = "Не удалось удалить товар по  причине - " + ex.Message });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Powered By Stegor";

            return View();
        }
    }
}