using FoodOrderApi.Models;
using FoodOrderApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService; //dependency injection
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            try
            {
                return Ok(_orderService.RetriveAllOrdersForCustomer());
            }
            catch (Exception ex)
            {
                //Log the error i.e., ex.Message
                return NotFound("Order not found");
            }
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> GetOrderById(int orderId)
        {
            try
            {
                return Ok(_orderService.RetriveSpecificOrderDetails(orderId));
            }
            catch (Exception ex)
            {
                //Log the error i.e., ex.Message
                return NotFound("Order not found");
            }
        }

        [HttpPost]
        public ActionResult<string> CreateOrder(Order order)
        {
            try
            {
                _orderService.PlaceOrder(order);
                return StatusCode(201, "Order Placed");
            }
            catch (Exception ex)
            {
                //Log the error i.e., ex.Message
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<string> ModifyOrder(Order order)
        {
            try
            {
                _orderService.ModifyOrder(order);
                return Ok("Order Modified");
            }
            catch (Exception ex)
            {
                //Log the error i.e., ex.Message
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public ActionResult<string> ModifyFoodQuantity(int orderId, int quantity)
        {
            try
            {
                _orderService.ModifyFoodQuantityInOrder(orderId, quantity);
                return Ok("Quantity for the order has been modified");
            }
            catch (Exception ex)
            {
                //Log the error i.e., ex.Message
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{orderId}")]
        public ActionResult<string> CancelOrder(int orderId)
        {
            try
            {
                _orderService.CancelOrder(orderId);
                return Ok("Order has been cancelled");
            }
            catch (Exception ex)
            {
                //Log the error i.e., ex.Message
                return BadRequest(ex.Message);
            }
        }
    }
}
