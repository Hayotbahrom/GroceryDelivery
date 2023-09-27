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
    public class DriverService : IDriverService
    {
        private long _id;
        private readonly Repository<Driver> driverRepository = new Repository<Driver>();

        public async Task<DriverForResultDto> CreateAsync(DriverForCreationDto dto)
        {
            var driver = (await driverRepository.SelectAllAsync()).
            FirstOrDefault(c => 
            c.FirstName.ToLower() == dto.FirsName.ToLower() && 
            c.LastName.ToLower() == dto.Lastname.ToLower()
            );
            if (driver != null)
                throw new CustomException(409, "Driver is already exist");

            await GenerateIdAsync();

            var driverForInsert = new Driver()
            {
                Id = _id,
                FirstName = dto.FirsName,
                LastName = dto.Lastname,
                Vehicle = dto.Vehicle
            };

            await driverRepository.InsertAsync(driverForInsert);

            var result = new DriverForResultDto()
            {
                Id = _id,
                FirsName = driverForInsert.FirstName,
                Lastname = driverForInsert.LastName
            };

            return result;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var driver = await driverRepository.SelectAllAsync();

            if (driver == null)
                throw new CustomException(404, "driver is not found");

            await driverRepository.DeleteAsynch(id);

            return true;
        }

        public async Task<List<DriverForResultDto>> GetAllAsync()
        {
            var drivers = await driverRepository.SelectAllAsync();
            var mappedDrivers = new List<DriverForResultDto>();

            foreach (var driver in drivers)
            {
                var item = new DriverForResultDto()
                {
                    Id = driver.Id,
                    FirsName = driver.FirstName,
                    Lastname = driver.LastName,
                    Vehicle = driver.Vehicle
                };
                mappedDrivers.Add(item);
            }

            return mappedDrivers;
        }

        public async Task<DriverForResultDto> GetByIdAsync(long id)
        {
            var driver = await driverRepository.SelectByIdAsync(id);
            if (driver is null)
                throw new CustomException(404, "driver is not found");

            var result = new DriverForResultDto()
            {
                Id = id,
                FirsName= driver.FirstName,
                Lastname = driver.LastName,
                Vehicle = driver.Vehicle
            };

            return result;
        }

        public async Task<DriverForResultDto> UpdateAsync(DriverForUpdateDto dto)
        {
            var driver = await driverRepository.SelectByIdAsync(dto.Id);
            if (driver == null)
                throw new CustomException(404, "driver is not found");

            var mappedDriver = new Driver()
            {
                Id = dto.Id,
                FirstName = dto.FirsName,
                LastName = dto.Lastname,
                UpdatedAt = DateTime.UtcNow
            };

            await driverRepository.UpdateAsync(mappedDriver);

            var result = new DriverForResultDto()
            {
                Id = dto.Id,
                FirsName = dto.FirsName,
                Lastname = dto.Lastname
            };

            return result;
        }

        public async Task<bool> SignInCheckAsync(string firstname, string lastname)
        {
            var requiredDriver = (await driverRepository.SelectAllAsync()).
                FirstOrDefault(d => d.FirstName == firstname && d.LastName == lastname);
            if (requiredDriver == null)
                return false;

            return true;
        }
        public async Task GenerateIdAsync()
        {
            var categories = await driverRepository.SelectAllAsync();
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
