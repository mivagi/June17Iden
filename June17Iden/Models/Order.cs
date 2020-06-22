using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace June17Iden.Models
{
    public class Order
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
