using FoodOrderApi.Models;
using FoodOrderApi.Repository;

//Service dosyası datayı geri aldığımızda ve datayı operasyonlarla
//değiştirmek,silmek,güncellemek istediğimizde  Service 
//classları içerisinde yaparız

namespace FoodOrderApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IFoodRepository _foodRepository;
        public OrderService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public void PlaceOrder(Order order)
        {
            try
            {
                var existingOrder = _foodRepository.FetchSpecificOrderDetails(order.OrderId);
                if (existingOrder != null)
                {
                    throw new Exception("Order already Exist!!");
                }
                _foodRepository.InsertOrder(order);
            }
            catch
            {
                throw;
            }
        }

        public List<Order> RetriveAllOrdersForCustomer()
        {
            try
            {
                return _foodRepository.FetchAllOrdersForCustomer();
            }
            catch
            {
                throw;
            }
        }

        public Order RetriveSpecificOrderDetails(int orderId)
        {
            try
            {
                return _foodRepository.FetchSpecificOrderDetails(orderId);
            }
            catch
            {
                throw;
            }
        }

        public void ModifyFoodQuantityInOrder(int orderId, int quantity)
        {
            try
            {
                var existingOrder = _foodRepository.FetchSpecificOrderDetails(orderId);
                if (existingOrder == null)
                {
                    throw new Exception("Order not found!!");
                }
                _foodRepository.UpdateFoodQuantityInOrder(orderId, quantity);
            }
            catch
            {
                throw;
            }
        }

        public void ModifyOrder(Order order)
        {
            try
            {
                var existingOrder = _foodRepository.FetchSpecificOrderDetails(order.OrderId);
                if (existingOrder == null)
                {
                    throw new Exception("Order not found!!");
                }
                _foodRepository.UpdateOrder(order);
            }
            catch
            {
                throw;
            }
        }
        public void CancelOrder(int orderId)
        {
            try
            {
                var existingOrder = _foodRepository.FetchSpecificOrderDetails(orderId);
                if (existingOrder == null)
                {
                    throw new Exception("Order not found!!");
                }
                _foodRepository.DeleteOrder(orderId);
            }
            catch
            {
                throw;
            }
        }


    }
}