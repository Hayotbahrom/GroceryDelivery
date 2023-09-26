using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.DTOs
{
    public class CategoryForUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
