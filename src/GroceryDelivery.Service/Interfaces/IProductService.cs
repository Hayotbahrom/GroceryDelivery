using GroceryDelivery.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductForResultDto>> GetAllAsync();
        public Task<ProductForResultDto> GetByIdAsync(long id);
        public Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto);
        public Task<bool> DeleteByIdAsync(long id);
        public Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto);
    }
}
