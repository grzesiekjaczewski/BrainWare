namespace Api.Controllers
{
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [ApiController]
    [Route("api")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("order/{id}")]

        public IEnumerable<Order> GetOrders(int id = 1)
        {
            return _orderService.GetOrdersForCompany(id);
        }
    }
}
