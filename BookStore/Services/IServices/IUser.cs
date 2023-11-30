using BooksModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel;

namespace BookStore.Services.IServices
{
    public interface IUser
    {
        Task<List<User>> GetUsersAsync();

        Task<string> AddUser(AddUser newUser);
    }
}
