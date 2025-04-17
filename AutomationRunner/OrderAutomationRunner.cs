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
                id = 2002,
                petId = 123456, // Use an existing PetId
                quantity = 1,
                shipDate = DateTime.UtcNow,
                status = "placed",
                complete = true
            };

            // 1. Place Order
            var placeOrderResponse = await OrderRestSharpClient.PlaceOrder(order);
            Console.WriteLine($"Place Order Status: {placeOrderResponse.StatusCode}");

            // 2. Get Order
            var getOrderResponse = await OrderRestSharpClient.GetOrder(order.id);
            Console.WriteLine($"Order Retrieved: {getOrderResponse.Data?.id}, Status: {getOrderResponse.Data?.status}");

            // 3. Delete Order
            var deleteOrderResponse = await OrderRestSharpClient.DeleteOrder(order.id);
            Console.WriteLine($"Delete Order Status: {deleteOrderResponse.StatusCode}");

            // 4. Confirm Deletion
            var confirmDeleteOrder = await OrderRestSharpClient.GetOrder(order.id);
            Console.WriteLine(confirmDeleteOrder.StatusCode == System.Net.HttpStatusCode.NotFound
                ? "Order successfully deleted."
                : "Order still exists.");
        }
    }
}
