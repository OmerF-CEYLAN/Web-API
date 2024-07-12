using FoodOrderApi.Models;

namespace FoodOrderApi.Repository
{
    public interface IFoodRepository
    {
        public void InsertOrder(Order order);

        public List<Order> FetchAllOrdersForCustomer();

        public Order FetchSpecificOrderDetails(int orderId);

        public void UpdateFoodQuantityInOrder(int orderId, int quantity);

        void UpdateOrder(Order order);
        public void DeleteOrder(int orderId);
    }
}
