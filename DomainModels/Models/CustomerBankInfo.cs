﻿namespace DomainModels.Models
{
    public class CustomerBankInfo : BaseModel
    {
        public decimal AccountBalance { get; set; } = 0.0m;
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public CustomerBankInfo(long customerId)
        {
            CustomerId = customerId;
        }
    }
}
