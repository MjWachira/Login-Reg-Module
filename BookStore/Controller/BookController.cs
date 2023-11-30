using BooksModels;
using BookStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controller
{
    public class BookController
    {
        
        BookService bookService = new BookService();

        public async Task init()
        {
            Console.WriteLine("1. Add a new Book");
            Console.WriteLine("2. Get all Books");
            Console.WriteLine("3. Update a Book");
            Console.WriteLine("4. Delete a Book");
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
                    await AddBook();
                    break;
                
                case 2:
                    await getBooks();
                    break;
               
                case 3:
                    await updateBook();
                    break;
        
                case 4:
                    await deleteBook();
                    break; 

            }

        }

        public async Task AddBook()
        {
            Console.WriteLine("Add a new Book");

            Console.WriteLine(" Book name: ");
            var Name = Console.ReadLine();

            Console.WriteLine(" Book Description: ");
            var Description = Console.ReadLine();


            


            var newBook = new AddBook() { Name = Name, Description = Description};
            await AddBookRequest(newBook);
            //validation

        }

        public async Task AddBookRequest(AddBook newBook)
        {
            //communicate with service

            var response = await bookService.AddBook(newBook);
            Console.WriteLine(response);
            await init();
        }
        
        public  async Task getBooks()
        {
            var books = await bookService.GetBooksAsync();
            Console.WriteLine($"Id \t Name \t Description");
            foreach (var book in books)
            {
                Console.WriteLine($" {book.Id} \t {book.Name} \t {book.Description}");
            }

        }

       
        public async Task updateBook()
        {
            await getBooks();
            Console.WriteLine("Select Book Update by Id :");
            var book = Console.ReadLine();
            var output = int.TryParse(book, out int bookID);
            Console.WriteLine("  Book Name: ");
            var Name = Console.ReadLine();

            Console.WriteLine(" Book Description: ");
            var Description = Console.ReadLine();


            
            var updatedBook = new AddBook() { Name = Name, Description = Description};
            await updateBookRequest(bookID, updatedBook);
        }


        public async Task updateBookRequest(int bookID, AddBook updatedBook)
        {
            var response = await bookService.UpdateBook(bookID, updatedBook);
            Console.WriteLine(response);
            await init();
        }
        
        public async Task deleteBook()
        {
            await getBooks();
            Console.WriteLine("Select a Book to Delete by Id :");
            var book = Console.ReadLine();
            var output = int.TryParse(book, out int bookID);
            var response = await bookService.DeleteBook(bookID);
            Console.WriteLine(response);
            await init();

        }
        
    }
}
