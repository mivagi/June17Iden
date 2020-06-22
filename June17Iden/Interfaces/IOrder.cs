using June17Iden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace June17Iden.Interfaces
{
    public interface IOrder
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
