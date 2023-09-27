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
    public class OrderService : IOrderService
    {
        private long _id;
        private readonly Repository<Order> orderRepository = new Repository<Order>();
        private readonly Repository<Driver> driverRepository = new Repository<Driver>();
        private readonly Repository<Product> productRepository = new Repository<Product>();
        public async Task<long> RandomDriverIdAsync()
        {
            var drivers = await driverRepository.SelectAllAsync();
            if (drivers is not null) 
            {
                long result= drivers.Max(d => d.Id);
                return result;
            }

            return 0;
        }

        public async Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto)
        {
            decimal totalFeePrice = (await productRepository.SelectByIdAsync(dto.ProductId)).Price;
            await GenerateIdAsync();

            var orderForInsert = new Order()
            {
                Id = _id,
                ProductId = dto.ProductId,
                CustomerId = dto.CustomerId,
                DriverId = dto.DriverId,
                Location = dto.Location,
                TotalAmount = dto.TotalAmount,
                TotalFee = (dto.TotalAmount*totalFeePrice),
                CreatedAt = DateTime.Now,
            };

            await orderRepository.InsertAsync(orderForInsert);

            var result = new OrderForResultDto()
            {
                Id = _id,
                ProductId = dto.ProductId,
                CustomerId = dto.CustomerId,
                DriverId = dto.DriverId,
                Location = dto.Location,
                TotalAmount = dto.TotalAmount,
                TotalFee = dto.TotalAmount*totalFeePrice
            };

            return result;
        }
        public async Task<List<OrderForResultDto>> GetAllAsync()
        {
            var orders = await orderRepository.SelectAllAsync();
            var mappedOrders = new List<OrderForResultDto>();

            foreach (var order in orders)
            {
                var item = new OrderForResultDto()
                {
                    Id = order.Id,
                    ProductId = order.ProductId,
                    CustomerId = order.CustomerId,
                    DriverId = order.DriverId,
                    Location = order.Location,
                    TotalAmount = order.TotalAmount,
                    TotalFee = order.TotalFee

                    
                };
                mappedOrders.Add(item);
            }

            return mappedOrders;
        }

        public async Task GenerateIdAsync()
        {
            var orders = await orderRepository.SelectAllAsync();
            if (orders.Count == 0)
            {
                this._id = 1;
            }
            else
            {
                var order = orders[orders.Count() - 1];
                this._id = ++order.Id;
            }
        }
    }
}
