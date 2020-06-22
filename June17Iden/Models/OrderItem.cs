using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace June17Iden.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person Person { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
