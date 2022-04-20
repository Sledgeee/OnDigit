using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.CartModel;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.OrderEditionModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnDigit.Infrastructure.Services
{
    public class OrderDataService : IOrderService
    {
        private readonly OnDigitDbContextFactory _contextFactory;
        private readonly DbSet<Order> _dbSet;

        public OrderDataService(OnDigitDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _dbSet = _contextFactory.CreateDbContext().Set<Order>();
        }

        public async Task CreateOrderAsync(string userId, Cart cart)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            Order order = (await context.AddAsync(new Order() { UserId = userId, TotalPrice = cart.TotalPrice })).Entity;
            await context.SaveChangesAsync();
            await CreateOrder(order.Number, cart.Editions);
        }

        private async Task CreateOrder(int orderNumber, ICollection<Edition> editions)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            foreach (var edition in editions)
                await context.AddAsync(new OrderEdition() { EditionId = edition.Id, OrderNumber = orderNumber });
            await context.SaveChangesAsync();
        }

        private IQueryable<Order> ApplySpecification(ISpecification<Order> specification) =>
            new SpecificationEvaluator().GetQuery(_dbSet, specification);

        public async Task<ICollection<Order>> GetOrdersBySpecAsync(ISpecification<Order> specification) =>
            await ApplySpecification(specification).ToListAsync();
    }
}
