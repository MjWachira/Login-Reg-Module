using BooksModels;
using BookStore.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel;

namespace BookStore.Services
{
    public class UserService:IUser
    {
        private readonly HttpClient _httpClient;
        private readonly string URL = "http://localhost:3000/users";

        public UserService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync(URL);
            var content = await response.Content.ReadAsStringAsync();//string
            var users = JsonConvert.DeserializeObject<List<User>>(content);
            if (response.IsSuccessStatusCode && users != null)
            {
                return users;
            }
            return new List<User>();

        }
        public async Task<string> AddUser(AddUser newUser)
        {
            var content = JsonConvert.SerializeObject(newUser);//request.body
            var body = new StringContent(content, Encoding.UTF8, "application/json");//JSON.stringify. to string
            var response = await _httpClient.PostAsync(URL, body);
            if (response.IsSuccessStatusCode)
            {
                return "User Registered Successfully";
            }
            return "";
        }
    }
}
