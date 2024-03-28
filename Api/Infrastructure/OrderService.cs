namespace Api.Infrastructure
{
    using System.Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class OrderService : IOrderService
    {
        private readonly BrainWareContext _context;
        public OrderService(BrainWareContext context) 
        {
            _context = context;
        }
        public List<OrderResult> GetOrdersForCompany(int CompanyId)
        {

            List<Order> orders = _context.Orders
                .Include(o => o.Company)
                .Include(o => o.Orderproducts)
                    .ThenInclude(op => op.Product)
                .Where(e => e.CompanyId == CompanyId)
                .ToList();

            var orderResults = new List<OrderResult>();

            foreach (var order in orders)
            {
                var orderProductResults = new List<OrderProductResult>();

                foreach(Orderproduct op in order.Orderproducts)
                {
                    orderProductResults.Add(new OrderProductResult
                    {
                        OrderId = op.OrderId,
                        ProductId = op.ProductId,
                        Price = op.Price!.Value,
                        Quantity = op.Quantity,
                        Product = new ProductResult
                        {
                             Name = op.Product!.Name,
                             Price = op.Product.Price!.Value
                        }
                    });
                }

                orderResults.Add(new OrderResult
                {
                    CompanyName = order.Company.Name,
                    Description = order.Description,
                    OrderId = order.OrderId,
                    OrderProducts = orderProductResults,
                    OrderTotal = orderProductResults.Sum(op => op.Price * op.Quantity)
                });
            }

            return orderResults;
        }
    }
}