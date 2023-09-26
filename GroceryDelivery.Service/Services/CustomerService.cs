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
    public class CustomerService : ICustomerService
    {
        private long _id;
        private readonly Repository<Customer> customerRepository = new Repository<Customer>();

        public async Task<CustomerForResultDto> CreateAsync(CustomerForCreationDto dto)
        {
            var customer = (await customerRepository.SelectAllAsync()).
            FirstOrDefault(c => c.Email.ToLower() == dto.Email.ToLower());
            if (customer != null)
                throw new CustomException(409, "customer is already exist");

            await GenerateIdAsync();

            var customerForInsert = new Customer()
            {
                Id = _id,
                FirstName = dto.FirtName,
                LastName = dto.Lastname,
                Email = dto.Email,
                Password = dto.Password,
                Address = dto.Address,
                CreatedAt = DateTime.Now,
            };

            await customerRepository.InsertAsync(customerForInsert);

            var result = new CustomerForResultDto()
            {
                Id = _id,
                FirstName = customerForInsert.FirstName,
                Lastname = customerForInsert.LastName,
                Email = customerForInsert.Email,
                Password = customerForInsert.Password,
                Address = customerForInsert.Address,
            };

            return result;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var category = await customerRepository.SelectAllAsync();

            if (category == null)
                throw new CustomException(404, "Category is not found");

            await customerRepository.DeleteAsynch(id);

            return true;
        }

        public async Task<List<CustomerForResultDto>> GetAllAsync()
        {
            var customers= await customerRepository.SelectAllAsync();
            var mappedCustomers = new List<CustomerForResultDto>();

            foreach (var category in customers)
            {
                var item = new CustomerForResultDto()
                {
                    Id = category.Id,
                    FirstName= category.FirstName,
                    Lastname= category.LastName,
                    Email = category.Email,
                    Password = category.Password,
                    Address = category.Address
                };
                mappedCustomers.Add(item);
            }

            return mappedCustomers;
        }

        public async Task<CustomerForResultDto> GetByIdAsync(long id)
        {
            var customer = await customerRepository.SelectByIdAsync(id);
            if (customer == null)
                throw new CustomException(404, "customer is not found");

            var result = new CustomerForResultDto()
            {
                Id = id,
                FirstName = customer.FirstName,
                Lastname = customer.LastName,
                Email = customer.Email,
                Password = customer.Password,
                Address = customer.Address
            };

            return result;
        }
        public async Task<CustomerForResultDto> SignInAsync(string email, string password)
        {
            var customers = await customerRepository.SelectAllAsync();
            var requiresCustomer = customers.FirstOrDefault(c => c.Email == email && c.Password == password);

            if (requiresCustomer != null)
            {
                var result = new CustomerForResultDto()
                {
                    Id = requiresCustomer.Id,
                    FirstName = requiresCustomer.FirstName,
                    Lastname = requiresCustomer.LastName,
                    Email = requiresCustomer.Email,
                    Password = requiresCustomer.Password,
                    Address = requiresCustomer.Address
                };
                return result;
            }
            else
            {
                throw new CustomException(404, "Customer not found");
            }


        }

        public async Task<CustomerForResultDto> UpdateAsync(CustomerForUpdateDto dto)
        {
            var customer = await customerRepository.SelectByIdAsync(dto.Id);
            if (customer == null)
                throw new CustomException(404, "customer is not found");

            var mappedCategory = new Customer()
            {
                Id = dto.Id,
                FirstName = dto.FirtName,
                LastName = dto.FirtName,
                Email = dto.Email,
                Password = dto.Password,
                Address = dto.Address,
                UpdatedAt = DateTime.UtcNow,
            };

            await customerRepository.UpdateAsync(mappedCategory);

            var result = new CustomerForResultDto()
            {
                Id = dto.Id,
                FirstName = dto.FirtName,
                Lastname= dto.FirtName,
                Email = dto.Email,
                Password = dto.Password,
                Address = dto.Address
            };

            return result;
        }

        public async Task GenerateIdAsync()
        {
            var customers = await customerRepository.SelectAllAsync();
            if (customers.Count == 0)
            {
                this._id = 1;
            }
            else
            {
                var category = customers[customers.Count() - 1];
                this._id = ++category.Id;
            }
        }
    }
}
