using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using June17Iden.Interfaces;
using June17Iden.Models;
using Microsoft.AspNetCore.Mvc;

namespace June17Iden.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPeople people;

        public AdminController(IPeople people)
        {
            this.people = people;
        }
        public IActionResult Index()
        {
            return View(people.People);
        }
        public IActionResult Edit(int id)
        {
            return View(people.People.FirstOrDefault(p => p.Id == id));
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                people.Create(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
        public IActionResult Create(Person person)
        {
            return View("Edit", new Person());
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            people.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
