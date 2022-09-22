namespace AppServices.Interfaces
{
    public interface ICustomerBankInfoAppServices
    {
        void Create(long customerId);
        decimal GetBalance(long customerId);
        void Deposit(long customerId, decimal amount);
        void Withdraw(long customerId, decimal amount);
    }
}
