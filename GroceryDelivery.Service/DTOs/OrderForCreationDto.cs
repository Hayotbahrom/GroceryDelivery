using GroceryDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.DTOs
{
    public class OrderForCreationDto
    {
        public long ProductId { get; set; }
        public long CustomerId { get; set; }
        public long DriverId { get; set; }
        public Product Product {  get; set; }
        public string Location { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
