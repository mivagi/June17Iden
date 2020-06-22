using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using June17Iden.Interfaces;
using June17Iden.Models;
using Microsoft.AspNetCore.Mvc;

namespace June17Iden.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }
        public IActionResult List()
        {
            return View(_order.Orders);
        }
        public IActionResult Order()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult SaveOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                _order.SaveOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "All right";
            return View();
        }
    }
}
