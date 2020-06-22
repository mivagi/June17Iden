using June17Iden.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace June17Iden.Models
{
    public class Cart
    {
        private List<PersonItem> personList = new List<PersonItem>();
        [JsonIgnore]
        public ISession Session { get; set; }
        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            Cart cart = session?.GetJson<Cart>("CartId") ?? new Cart();
            cart.Session = session;

            return cart;
        }
        public void AddToCart(Person person, int quantity)
        {
            PersonItem item = personList.Where(p => p.Person.Id == person.Id).FirstOrDefault();
            if(item == null)
            {
                personList.Add(new PersonItem { Person = person, Quantity = quantity, Name = person.Name });
            }
            else
            {
                item.Quantity += quantity;
            }
            Session.SetJson("CartId", this);
        }
        public virtual IEnumerable<PersonItem> GetAllPersonItems => personList;
    }
}
