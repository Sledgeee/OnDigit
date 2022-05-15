using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderBookModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using OnDigit.Core.Models.PaymentModel;
using OnDigit.Core.Models.WarehouseModel;
using OnDigit.Core.Models.SaleModel;

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

        public async Task CreateOrderAsync(string userId, string userFullname, string userPhone,
                                           string userEmail, Dictionary<Book, Tuple<int, decimal>> books, decimal totalAmount, 
                                           DeliveryCompany deliveryCompany, string deliveryAddress, string cardToPay)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            bool isPaid = !string.IsNullOrEmpty(cardToPay);
            Order order = (await context.Orders.AddAsync(new Order() 
            { 
                UserId = userId,
                ContactPhone = userPhone,
                Email = userEmail,
                Fullname = userFullname,
                TotalAmount = totalAmount,
                TotalBooksQuantity = books.Sum(x => x.Value.Item1),
                DeliveryCompany = deliveryCompany,
                DeliveryAddress = deliveryAddress,
                PayStatus = isPaid ? PayStatus.Paid : PayStatus.Unpaid,
                OrderStatus = OrderStatus.Payment
            })).Entity;

            await context.SaveChangesAsync();
            await CreateOrdersBooks(order.Number, books, isPaid);
            if (isPaid)
            {
                await CompleteOrder(order.Number, userId, totalAmount, cardToPay, books);
            }
        }

        public async Task CompleteOrder(int orderNumber, string userId, decimal totalAmount, string cardToPay, Dictionary<Book, Tuple<int, decimal>> books)
        {
            await CreatePayment(orderNumber, userId, totalAmount, cardToPay);
            foreach (var book in books)
            {
                await CreateSales(book.Key.Id, book.Value.Item1);
                book.Key.Package = await ChangePackageQuantity(book.Key.Id, book.Value.Item1);
            }
        }

        private async Task CreateOrdersBooks(int orderNumber, Dictionary<Book, Tuple<int, decimal>> books, bool isPaid)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();

            List<OrdersBooks> entities = new List<OrdersBooks>();

            foreach (var book in books)
            {
                entities.Add(new OrdersBooks()
                {
                    BookId = book.Key.Id,
                    Quantity = book.Value.Item1,
                    UnitPrice = book.Key.Price,
                    OrderNumber = orderNumber
                });

                if (isPaid)
                {
                    book.Key.Package = await ChangePackageQuantity(book.Key.Id, book.Value.Item1);
                }
            }
            await context.OrdersBooks.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        private async Task CreateSales(string bookId, int quantity)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            Sale sale = await context.Sales.FirstOrDefaultAsync(x => x.BookId == bookId);

            if (sale == null)
            {
                await context.Sales.AddAsync(new()
                {
                    BookId = bookId,
                    Quantity = quantity
                });
            }
            else
            {
                sale.Quantity += quantity;
                context.Sales.Update(sale);
            }
            await context.SaveChangesAsync();
        }

        private async Task<Package> ChangePackageQuantity(string bookId, int quantity)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            Package package = await context.Packages.FirstOrDefaultAsync(x => x.BookId == bookId);
            package.Quantity -= quantity;
            context.Packages.Update(package);
            await context.SaveChangesAsync();
            return package;
        }

        private async Task CreatePayment(int orderNumber, string userId, decimal totalAmount, string cardToPay)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            await context.Payments.AddAsync(new Payment()
            {
                UserId = userId,
                OrderNumber = orderNumber,
                Amount = totalAmount,
                CardNumber = cardToPay
            });
            var order = await context.Orders.FirstAsync(x => x.Number == orderNumber);
            order.PayStatus = PayStatus.Paid;
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }

        private IQueryable<Order> ApplySpecification(ISpecification<Order> specification) =>
            new SpecificationEvaluator().GetQuery(_dbSet, specification);

        public async Task<ICollection<Order>> GetOrdersBySpecAsync(ISpecification<Order> specification) =>
            await ApplySpecification(specification).ToListAsync();
    }
}
