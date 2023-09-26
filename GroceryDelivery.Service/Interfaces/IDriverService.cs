using GroceryDelivery.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.Interfaces
{
    public interface IDriverService
    {
        public Task<List<DriverForResultDto>> GetAllAsync();
        public Task<DriverForResultDto> GetByIdAsync(long id);
        public Task<DriverForResultDto> UpdateAsync(DriverForUpdateDto dto);
        public Task<bool> DeleteByIdAsync(long id);
        public Task<DriverForResultDto> CreateAsync(DriverForCreationDto dto);
    }
}
