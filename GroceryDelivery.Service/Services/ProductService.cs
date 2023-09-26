using GroceryDelivery.Data.Repositoris;
using GroceryDelivery.Domain.Entities;
using GroceryDelivery.Service.DTOs;
using GroceryDelivery.Service.Exceptions;
using GroceryDelivery.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.Services
{
    public class ProductService : IProductService
    {
        private long _id;
        private readonly Repository<Product> productRepository = new Repository<Product>();

        public async Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto)
        {
            var product = (await productRepository.SelectAllAsync()).
            FirstOrDefault(c => c.Name.ToLower() == dto.Name.ToLower());
            if (product != null)
                throw new CustomException(409, "product is already exist");

            await GenerateIdAsync();

            var categoryForInsert = new Product()
            {
                Id = _id,
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                Price = dto.Price,
                Quantity = dto.Quantity
            };

            await productRepository.InsertAsync(categoryForInsert);

            var result = new ProductForResultDto()
            {
                Id = _id,
                Name = categoryForInsert.Name,

            };

            return result;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var category = await productRepository.SelectAllAsync();

            if (category == null)
                throw new CustomException(404, "product is not found");

            await productRepository.DeleteAsynch(id);

            return true;
        }

        public async Task<List<ProductForResultDto>> GetAllAsync()
        {
            var categories = await productRepository.SelectAllAsync();
            var mappedCategories = new List<ProductForResultDto>();

            foreach (var category in categories)
            {
                var item = new ProductForResultDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                    CategoryId = category.CategoryId,
                    Price = category.Price,
                    Quantity = category.Quantity
                };
                mappedCategories.Add(item);
            }

            return mappedCategories;
        }

        public async Task<ProductForResultDto> GetByIdAsync(long id)
        {
            var pro = await productRepository.SelectByIdAsync(id);
            if (pro == null)
                throw new CustomException(404, "product is not found");

            var result = new ProductForResultDto()
            {
                Id = id,
                CategoryId= pro.CategoryId,
                Name = pro.Name,
                Price = pro.Price,
                Quantity = pro.Quantity
            };

            return result;
        }

        public async Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto)
        {
            var pro = await productRepository.SelectByIdAsync(dto.Id);
            if (pro == null)
                throw new CustomException(404, "product is not found");

            var mappedProduct = new Product()
            {
                Id = dto.Id,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,
                UpdatedAt = DateTime.UtcNow,
            };

            await productRepository.UpdateAsync(mappedProduct);

            var result = new ProductForResultDto()
            {
                Id = dto.Id,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,
            };

            return result;
        }
        public async Task GenerateIdAsync()
        {
            var categories = await productRepository.SelectAllAsync();
            if (categories.Count == 0)
            {
                this._id = 1;
            }
            else
            {
                var category = categories[categories.Count() - 1];
                this._id = ++category.Id;
            }
        }
    }
}
