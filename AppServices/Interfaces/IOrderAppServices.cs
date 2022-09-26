﻿using AppModels.Mapper.Order;
using DomainModels.Models;

namespace AppServices.Interfaces
{
    public interface IOrderAppServices
    {
        Task<long> CreateAsync(CreateOrder model);
        IEnumerable<OrderResult> GetAll();
        Task<OrderResult> GetByIdAsync(long id);
        IList<Order> GetOrdersToExecute();
        int GetAvailableQuotes(long portfolioId, long productId);
        void Update(long id, UpdateOrder model);
        void Delete(long id);
    }
}
