using BookStore.Models.Book;
using BookStore.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookStore.Services.IServices
{
    public interface IUser
    {
        Task<List<User>> GetUsersAsync();

        Task<string> AddUser(AddUser newUser);
    }
}
