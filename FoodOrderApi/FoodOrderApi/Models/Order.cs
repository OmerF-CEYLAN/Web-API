using System.Security.Cryptography.X509Certificates;

namespace FoodOrderApi.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        public int CustomerName { get; set; }
        public int FoodItem { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }


        public Order(Order order)
        {
            OrderId = order.OrderId;
            CustomerName = order.CustomerName;
            FoodItem = order.FoodItem;
            Quantity = order.Quantity;
            OrderTime = order.OrderTime;
        }

        public Order() { }



    }

}
