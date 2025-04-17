using RestSharpAPI.Models;
using RestSharpAPI.RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.AutomationRunner
{
    internal class OrderAutomationRunner
    {
        public static async Task Run()
        {
            Console.WriteLine("----- ORDER AUTOMATION -----");

            var order = new Order
            {
                Id = 2002,
                PetId = 1, // Use an existing PetId
                Quantity = 1,
                ShipDate = DateTime.UtcNow.ToString(),
                Status = "placed",
                Complete = true
            };

            // 1. Place Order
            var placeOrderResponse = await OrderRestSharpClient.PlaceOrder(order);
            Console.WriteLine($"Place Order Status: {placeOrderResponse.StatusCode}");

            // 2. Get Order
            var getOrderResponse = await OrderRestSharpClient.GetOrder(order.Id);
            Console.WriteLine($"Order Retrieved: {getOrderResponse.Data?.Id}, Status: {getOrderResponse.Data?.Status}");

            // 3. Delete Order
            var deleteOrderResponse = await OrderRestSharpClient.DeleteOrder(order.Id);
            Console.WriteLine($"Delete Order Status: {deleteOrderResponse.StatusCode}");

            // 4. Confirm Deletion
            var confirmDeleteOrder = await OrderRestSharpClient.GetOrder(order.Id);
            Console.WriteLine(confirmDeleteOrder.StatusCode == System.Net.HttpStatusCode.NotFound
                ? "Order successfully deleted."
                : "Order still exists.");
        }
    }
}
