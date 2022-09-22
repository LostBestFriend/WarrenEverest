using AppServices.Interfaces;
using DomainServices.Interfaces;

namespace AppServices.Services
{
    public class CustomerBankInfoAppServices : ICustomerBankInfoAppServices
    {
        private readonly ICustomerBankInfoServices _customerBankInfoServices;

        public CustomerBankInfoAppServices(ICustomerBankInfoServices customerBankInfoServices)
        {
            _customerBankInfoServices = customerBankInfoServices ?? throw new ArgumentNullException(nameof(customerBankInfoServices));   
        }

        public void Create(long customerId)
        {
            _customerBankInfoServices.Create(customerId);
        }

        public void Deposit(long customerId, decimal amount)
        {
            _customerBankInfoServices.Deposit(customerId, amount);
        }

        public decimal GetBalance(long customerId)
        {
            return _customerBankInfoServices.GetBalance(customerId);
        }

        public void Withdraw(long customerId, decimal amount)
        {
            _customerBankInfoServices.Withdraw(customerId, amount);
        }
    }
}
