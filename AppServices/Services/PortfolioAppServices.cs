using AppModels.Mapper.Order;
using AppModels.Mapper.Portfolio;
using AppServices.Interfaces;
using AutoMapper;
using DomainModels.Models;
using DomainServices.Interfaces;
using EntityFrameworkCore.UnitOfWork.Factories;
using System.Transactions;

namespace AppServices.Services
{
    public class PortfolioAppServices : IPortfolioAppServices
    {
        private readonly IPortfolioServices _portfolioServices;
        private readonly IMapper _mapper;
        private readonly ICustomerBankInfoAppServices _customerBankInfoAppServices;
        private readonly IProductAppServices _productAppServices;
        private readonly IOrderAppServices _orderAppServices;
        private readonly IPortfolioProductServices _portfolioProductServices;

        public PortfolioAppServices(IPortfolioServices portfolio, IMapper mapper, ICustomerBankInfoAppServices customerBankInfoAppServices, IProductAppServices productAppServices, IOrderAppServices orderAppServices, IPortfolioProductServices portfolioProductServices)
        {
            _portfolioServices = portfolio ?? throw new ArgumentNullException(nameof(portfolio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerBankInfoAppServices = customerBankInfoAppServices ?? throw new ArgumentNullException(nameof(customerBankInfoAppServices));
            _productAppServices = productAppServices ?? throw new ArgumentNullException(nameof(productAppServices));
            _orderAppServices = orderAppServices ?? throw new ArgumentNullException(nameof(orderAppServices));
            _portfolioProductServices = portfolioProductServices ?? throw new ArgumentNullException(nameof(portfolioProductServices));
        }

        public async Task<long> CreateAsync(CreatePortfolio model)
        {
            Portfolio portfolio = _mapper.Map<Portfolio>(model);
            return await _portfolioServices.CreateAsync(portfolio).ConfigureAwait(false);
        }

        public IEnumerable<PortfolioResult> GetAll()
        {
            var result = _portfolioServices.GetAll();
            return _mapper.Map<IEnumerable<PortfolioResult>>(result);
        }

        public async Task<PortfolioResult> GetByIdAsync(long id)
        {
            var result = await _portfolioServices.GetByIdAsync(id).ConfigureAwait(false);
            return _mapper.Map<PortfolioResult>(result);
        }

        public decimal GetBalance(long portfolioId)
        {
            return _portfolioServices.GetBalance(portfolioId);
        }

        public void Deposit(decimal amount, long customerId, long portfolioId)
        {
            if (_customerBankInfoAppServices.GetBalance(customerId) < amount)
            {
                throw new ArgumentException("Não há saldo suficiente na conta corrente para realizar este depósito");
            }

            using var transactionScope = TransactionScopeFactory.CreateTransactionScope();
            _customerBankInfoAppServices.Withdraw(customerId, amount);
            _portfolioServices.Deposit(amount, portfolioId);
            transactionScope.Complete();
        }

        public void Withdraw(decimal amount, long customerId, long portfolioId)
        {
            if (_portfolioServices.GetBalance(portfolioId) < amount)
            {
                throw new ArgumentException("Não há saldo suficiente na carteira para realizar o saque requerido");
            }

            using var transactionScope = TransactionScopeFactory.CreateTransactionScope();
            _portfolioServices.Withdraw(amount, portfolioId);
            _customerBankInfoAppServices.Deposit(customerId, amount);
            transactionScope.Complete();
        }

        public async Task InvestAsync(int quotes, DateTime liquidateAt, long productId, long portfolioId)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var product = await _productAppServices.GetByIdAsync(productId);
            var portfolio = await _portfolioServices.GetByIdAsync(portfolioId);
            decimal amount = product.UnitPrice * quotes;
            var order = new CreateOrder(quotes, product.UnitPrice, amount,
                                        liquidateAt, AppModels.Enums.OrderDirection.Buy, productId, portfolioId);
            var orderId = await _orderAppServices.CreateAsync(order).ConfigureAwait(false);

            if (portfolio.TotalBalance < amount)
            {
                throw new ArgumentException("Não há saldo suficiente na carteira para realizar este investimento");
            }

            if (DateTime.Now.Date >= liquidateAt.Date)
            {
                var orderResult = await _orderAppServices.GetByIdAsync(orderId);
                ExecuteBuyOrder(orderResult);
            }
            transactionScope.Complete();
        }

        public async Task UninvestAsync(int quotes, DateTime liquidateAt, long productId, long portfolioId)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var product = await _productAppServices.GetByIdAsync(productId).ConfigureAwait(false);
            var portfolio = await _portfolioServices.GetByIdAsync(portfolioId).ConfigureAwait(false);
            int availableQuotes = _orderAppServices.GetAvailableQuotes(portfolioId, productId);

            if (quotes > availableQuotes)
            {
                throw new ArgumentException("A quantidade de cotas informada é maior do que as cotas existentes na carteira");
            }

            decimal amount = product.UnitPrice * quotes;
            var createOrder = new CreateOrder(quotes, product.UnitPrice, amount,
                                        liquidateAt, AppModels.Enums.OrderDirection.Sell, productId, portfolioId);
            var orderId = await _orderAppServices.CreateAsync(createOrder).ConfigureAwait(false);


            if (DateTime.Now.Date >= liquidateAt.Date)
            {
                var orderResult = await _orderAppServices.GetByIdAsync(orderId);
                ExecuteSellOrder(orderResult);
            }
            transactionScope.Complete();
        }

        public void ExecuteTodaysOrders()
        {
            var orders = _orderAppServices.GetOrdersToExecute();

            foreach (var order in orders)
            {
                if (order.Direction == AppModels.Enums.OrderDirection.Buy)
                {
                    ExecuteBuyOrder(order);
                }
                else
                {
                    ExecuteSellOrder(order);
                }
            }
        }

        public void ExecuteBuyOrder(OrderResult order)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _portfolioServices.Withdraw(order.NetValue, order.PortfolioId);

            if (!_portfolioProductServices.RelationExists(order.PortfolioId, order.ProductId)) 
            {
                _portfolioProductServices.CreateRelation(order.PortfolioId, order.ProductId);
            }
            transactionScope.Complete();
        }

        public void ExecuteSellOrder(OrderResult order)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _portfolioServices.Deposit(order.NetValue, order.PortfolioId);
            int availableQuotes = _orderAppServices.GetAvailableQuotes(order.PortfolioId, order.ProductId);

            if (availableQuotes == order.Quotes)
            {
                _portfolioProductServices.DeleteRelation(order.PortfolioId, order.ProductId);

            }
            transactionScope.Complete();
        }

        public void Delete(long portfolioId)
        {
            _portfolioServices.Delete(portfolioId);
        }
    }
}
