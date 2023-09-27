using GroceryDelivery.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryForResultDto>> GetAllAsync();
        public Task<CategoryForResultDto> GetByIdAsync(long id);
        public Task<CategoryForResultDto> UpdateAsync(CategoryForUpdateDto dto);
        public Task<bool> DeleteByIdAsync(long id);
        public Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto); 
    }
}
