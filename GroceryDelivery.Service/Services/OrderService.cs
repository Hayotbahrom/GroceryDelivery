using GroceryDelivery.Data.Repositoris;
using GroceryDelivery.Domain.Entities;
using GroceryDelivery.Service.DTOs;
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
