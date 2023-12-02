using BookStore.Models.Order;

namespace BookStore.Services.IServices
{
    public interface IOrder
    {
        Task<List<Order>> GetOrderAsync();

        Task<string> AddOrder(Order newOrder);
    }
}
