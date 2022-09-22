namespace DomainServices.Interfaces
{
    public interface ICustomerBankInfoServices
    {
        void Create(long customerId);
        decimal GetBalance(long customerId);
        void Deposit(long customerId, decimal amount);
        void Withdraw(long customerId, decimal amount);
    }
}
