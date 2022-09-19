﻿using AppModels.Mapper;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        long Create(CustomerCreateDto model);
        void Delete(int id);
        List<CustomerResultDto> GetAll();
        CustomerResultDto? GetByCpf(string cpf);
        CustomerResultDto? GetById(int id);
        void Update(long id, CustomerUpdateDto model);
    }
}