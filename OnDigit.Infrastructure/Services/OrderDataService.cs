using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.CartModel;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderBookModel;
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
            Order order = (await context.AddAsync(new Order() { UserId = userId })).Entity;
            await context.SaveChangesAsync();
            await CreateOrder(order.Number, cart.Books);
        }

        private async Task CreateOrder(int orderNumber, Dictionary<Book, int> books)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            foreach (var book in books)
                await context.AddAsync(new OrdersBooks() { BookId = book.Key.Id, Quantity = book.Value, UnitPrice = book.Key.Price, OrderNumber = orderNumber });
            await context.SaveChangesAsync();
        }

        private IQueryable<Order> ApplySpecification(ISpecification<Order> specification) =>
            new SpecificationEvaluator().GetQuery(_dbSet, specification);

        public async Task<ICollection<Order>> GetOrdersBySpecAsync(ISpecification<Order> specification) =>
            await ApplySpecification(specification).ToListAsync();
    }
}
