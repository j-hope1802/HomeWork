using Domain.Dtos;
using Infrastructure.OrderService;
using Microsoft.AspNetCore.Mvc;
namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController
    {
        private OrderService _orderService;

        public OrdersController()
        {
            _orderService = new OrderService();
        }


        [HttpGet]
        public List<Orders> GetOrder()
        {
            return _orderService.GetOrder();
        }
        [HttpPost("Insert")]
        public int InsertOrder(Orders orders)
        {
            return _orderService.InsertOrder(orders);
        }

        [HttpPut]
        public int UpdateOrder(Orders orders)
        {
            return _orderService.UpdateOrder(orders);
        }

        [HttpDelete]
        public int DeleteOrder(int id)
        {
            return _orderService.DeleteOrder(id);
        }



    }
}
