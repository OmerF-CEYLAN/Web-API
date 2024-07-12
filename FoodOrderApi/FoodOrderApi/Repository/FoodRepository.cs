using FoodOrderApi.Models;
using FoodOrderApi.Repository;
using System.Linq;

namespace FoodOrderApi.Repository
{
    public class FoodRepository : IFoodRepository
    {
        static List<Order> orders = new List<Order>();
        public void InsertOrder(Order order)
        {
            orders.Add(order);
        }

        public List<Order> FetchAllOrdersForCustomer()
        {
            return orders;
        }

        public Order FetchSpecificOrderDetails(int orderId)
        {
            
            return orders.FirstOrDefault(order => order.OrderId == orderId);
        }

        public void UpdateFoodQuantityInOrder(int orderId, int quantity)
        {
            Order orderToUpdate = orders.First(order => order.OrderId == orderId);

            if (orderToUpdate != null)
            {
                orderToUpdate.Quantity = quantity;
            }
        }

        public void UpdateOrder(Order order)
        {
            Order orderToUpdate = orders.First(order => order.OrderId == order.OrderId);
            if (orderToUpdate != null)
            {
                orderToUpdate = order;
            }
        }

        public void DeleteOrder(int orderId)
        {
            Order orderToDelete = orders.First(order => order.OrderId == orderId);
            if (orderToDelete != null)
            {
                orders.Remove(orderToDelete);
            }
        }
    }
}