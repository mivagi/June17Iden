using June17Iden.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace June17Iden.Models
{
    public class OrderRepository : IOrder
    {
        private readonly AppDbContent content;
        private readonly Cart cart;

        public OrderRepository(AppDbContent content, Cart cart)
        {
            this.content = content;
            this.cart = cart;
        }
        public IEnumerable<Order> Orders => content.Orders.Include(p => p.OrderItems).ThenInclude(l => l.Person);
        public void SaveOrder(Order order)
        {
            content.Orders.Add(order);
            content.SaveChanges();
            var items = cart.GetAllPersonItems;
            foreach (var person in items)
            {
                content.OrderItems.Add(
                    new OrderItem
                    {
                        OrderId = order.Id,
                        Name = person.Name,
                        Quantity = person.Quantity
                    });
            }
            content.SaveChanges();
        }
    }
}
