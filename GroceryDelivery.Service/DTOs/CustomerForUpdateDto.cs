using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.DTOs
{
    public class CustomerForUpdateDto
    {
        public long Id { get; set; }
        public string FirtName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
