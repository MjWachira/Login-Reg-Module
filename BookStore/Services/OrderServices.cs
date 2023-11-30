using BookStore.Services.IServices;
using Newtonsoft.Json;
using OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel;

namespace BookStore.Services
{
    internal class OrderServices:IOrder
    {
        private readonly HttpClient _httpClient;
        private readonly string URL = "http://localhost:3000/orders";

        public OrderServices()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Order>> GetOrderAsync()
        {
            var response = await _httpClient.GetAsync(URL);
            var content = await response.Content.ReadAsStringAsync();//string
            var orders = JsonConvert.DeserializeObject<List<Order>>(content);
            if (response.IsSuccessStatusCode && orders != null)
            {
                return orders;
            }
            return new List<Order>();

        }
        public async Task<string> AddOrder(Order newOrder)
        {
            var content = JsonConvert.SerializeObject(newOrder);//request.body
            var body = new StringContent(content, Encoding.UTF8, "application/json");//JSON.stringify. to string
            var response = await _httpClient.PostAsync(URL, body);
            if (response.IsSuccessStatusCode)
            {
                return "Order Added Successfully";
            }
            return "";
        }
    }
}
