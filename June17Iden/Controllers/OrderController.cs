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
        private readonly Cart cart;

        public OrderController(IOrder order, Cart cart)
        {
            _order = order;
            this.cart = cart;
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
            //cart.Clear();
            return View();
        }
    }
}
