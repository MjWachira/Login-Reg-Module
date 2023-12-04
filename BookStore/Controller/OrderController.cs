using BookStore.Models.Order;
using BookStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controller
{
    public class OrderController
    {
        OrderServices orderServices = new OrderServices();
        BookController bookController = new BookController();

        public async Task init()
        {
            Console.WriteLine("1. Add a new Order");
            Console.WriteLine("2. View Orders");

            Console.WriteLine("Enter your input:");
            var input = Console.ReadLine();

            Console.WriteLine(input);

            // convert this input to int

            var output = int.TryParse(input, out int option);
            // errors incase user enters a string/char
            // validation number is between 1 and 4

            // switch
            await redirectUser(option);
        }

        public async Task redirectUser(int option)
        {
            switch (option)
            {
                case 1:
                    await AddOrder();
                    break;

                case 2:
                    await getOrder();
                    break;
            }
        }
        public async Task AddOrder()
        {
            Console.WriteLine("Buy a Book");
            await bookController.getBooks();
            Console.WriteLine("Select a Book ID:");
            var BookId = Console.ReadLine();

            Console.WriteLine("Your ID:");

            var UserId = Console.ReadLine();

            var newOrder = new Order() { BookID = BookId, UserID = UserId };
            await AddOrderRequest(newOrder);

            }
        public async Task AddOrderRequest(Order newOrder)
        {
            // communicate with service
            var response = await orderServices.AddOrder(newOrder);
            Console.WriteLine(response);
        }
        public async Task getOrder()
        {
            var orders = await orderServices.GetOrderAsync();
            Console.WriteLine($"Id \t Book ID\t UserID\t");

            foreach(var order in orders)
            {Console.WriteLine($" {order.Id} \t {order.BookID} \t {order.UserID}");
            }
        }
    }
}
