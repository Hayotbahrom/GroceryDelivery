using GroceryDelivery.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<CustomerForResultDto>> GetAllAsync();
        public Task<CustomerForResultDto> GetByIdAsync(long id);
        public Task<CustomerForResultDto> UpdateAsync(CustomerForUpdateDto dto);
        public Task<bool> DeleteByIdAsync(long id);
        public Task<CustomerForResultDto> CreateAsync(CustomerForCreationDto dto);
    }
}
