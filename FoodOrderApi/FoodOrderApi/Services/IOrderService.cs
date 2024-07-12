using FoodOrderApi.Models;

namespace FoodOrderApi.Services
{
    public interface IOrderService
    {

        public void PlaceOrder(Order order);


        public List<Order> RetriveAllOrdersForCustomer();


        public Order RetriveSpecificOrderDetails(int orderId);


        public void ModifyFoodQuantityInOrder(int orderId, int quantity);

        public void ModifyOrder(Order order);

        public void CancelOrder(int orderId);

    }
}
