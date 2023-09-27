using GroceryDelivery.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<List<OrderForResultDto>> GetAllAsync();
    }
}
