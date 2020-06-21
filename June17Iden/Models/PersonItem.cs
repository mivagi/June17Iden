using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace June17Iden.Models
{
    public class PersonItem
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int Quantity { get; set; }
    }
}
