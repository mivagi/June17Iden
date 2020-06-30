using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using June17Iden.Models;
using Microsoft.AspNetCore.Mvc;

namespace June17Iden.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContent content;
        private readonly Cart cart;

        public CartController(AppDbContent content, Cart cart)
        {
            this.content = content;
            this.cart = cart;
        }
        public IActionResult CartIndex()
        {
            return View(cart.GetAllPersonItems);
        }
        public IActionResult AddToCart(int id)
        {
            Person person = content.People.FirstOrDefault(p => p.Id == id);
            if(person != null)
            {
                cart.AddToCart(person, 1);
            }

            return RedirectToAction("CartIndex");
        }
        public IActionResult Remove(int id)
        {
            var person = content.People.FirstOrDefault(p => p.Id == id);
            cart.RemovePerson(person);
            return RedirectToAction("CartIndex");
        }
    }
}
