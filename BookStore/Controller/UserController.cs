using BooksModels;
using BookStore.Services;
using BookStore.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel;

namespace BookStore.Controller
{
    public class UserController:BookController
    {

        UserService userService = new UserService();
        BookController BookController = new BookController();

        public async Task init()
        {
            Console.WriteLine("######################################");
            Console.WriteLine("************ USER PANEL **************");
            Console.WriteLine("#######################################");
            Console.WriteLine("1. User Login");
            Console.WriteLine("2. User Registration");
            Console.WriteLine("Enter your input:");
            var input = Console.ReadLine();
            Console.WriteLine(input);

            //convert this input to int

            var output = int.TryParse(input, out int option);
            //errors incase user enters a string/char
            //validation number is between 1 and 4


            //switch
            await redirectUser(option);
        }

        public async Task redirectUser(int option)
        {
            switch (option)
            {
                case 1:
                    await getUsers();
                    break;
                    
               
                case 2:
                    await AddUser();
                    break;
                    /*
                case 3:
                    await updateBook();
                    break;

                case 4:
                    await deleteBook();
                    break;*/

            }

        }


        public async Task getUsers()
        {
            Console.WriteLine("######################################");
            Console.WriteLine("************ USER Login **************");
            Console.WriteLine("#######################################");
            Console.WriteLine("");


            var users = await userService.GetUsersAsync();

            Console.WriteLine($"Id \t Name \t Password");

            foreach (var user in users)
            {
                Console.WriteLine($" {user.Id} \t {user.UserName} \t {user.Password}"); 

            }
            Console.WriteLine("~~~~~~~ Enter Your Login Details ~~~~~~~~~~");
            Console.WriteLine("Enter Username");

            string userName2 = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password2 = Console.ReadLine();

            try 
            {
                foreach (var user in users)
                {
                    if (user.UserName == userName2 && user.Password == password2)
                    {
                        await Console.Out.WriteLineAsync("");

                        await Console.Out.WriteLineAsync("login successfull....");
                        await Console.Out.WriteLineAsync("");
                        Console.WriteLine($"########## Welcome: {userName2.ToUpper()} ##########");
                        await Console.Out.WriteLineAsync("");
                        await getBooks();
                        break;
                     }
                    else
                    {
                        Console.WriteLine("Incorrect Details Login again...");
                    }
                    
                    
                    

                }
                await init();
            }
            catch
            {
                
            }
           

          
                
            

        }

        public async Task AddUser()
        {
            Console.WriteLine("######################################");
            Console.WriteLine("********** USER REGISTRATION *********");
            Console.WriteLine("#######################################");

            Console.WriteLine("Enter Your Details");

            Console.WriteLine(" Enter username: ");
            var UserName = Console.ReadLine();

            Console.WriteLine(" Enter Password: ");
            var Password = Console.ReadLine();

            var newUser = new AddUser() { UserName = UserName, Password = Password };

            await AddUsersRequest(newUser);
            //validation
        }        
        public async Task AddUsersRequest(AddUser newUser)
        {
            //communicate with service
            var response = await userService.AddUser(newUser);
            Console.WriteLine(response);
            await init();
        }

    }
}
