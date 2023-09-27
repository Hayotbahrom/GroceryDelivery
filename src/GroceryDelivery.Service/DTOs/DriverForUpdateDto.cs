using GroceryDelivery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.DTOs
{
    public class DriverForUpdateDto
    {
        public long Id { get; set; }
        public string FirsName { get; set; }
        public string Lastname { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
