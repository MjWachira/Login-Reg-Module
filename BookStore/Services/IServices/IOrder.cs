using OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel;

namespace BookStore.Services.IServices
{
    public interface IOrder
    {
        Task<List<Order>> GetOrderAsync();

        Task<string> AddOrder(Order newOrder);
    }
}
