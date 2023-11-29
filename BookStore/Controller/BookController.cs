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
                    /*
                case 3:
                    await updateProductUI();
                    break;
                case 4:
                    await deleteProduct();
                    break; */

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
        
        public async Task getBooks()
        {
            var books = await BookService.GetBooksAsync();
            Console.WriteLine($"Id \t Name \t Description");
            foreach (var book in books)
            {
                Console.WriteLine($" {book.Id} \t {book.Name} \t {book.Description}");
            }
        }
        /*
        public async Task updateProductUI()
        {
            await showProducts();
            Console.WriteLine("Select Product Update by Id :");
            var prod = Console.ReadLine();
            var output = int.TryParse(prod, out int ProductId);
            Console.WriteLine("  Product Name: ");
            var Name = Console.ReadLine();

            Console.WriteLine(" Product Description: ");
            var Description = Console.ReadLine();


            Console.WriteLine(" Product Price: ");
            var priceStr = Console.ReadLine();
            var res = int.TryParse(priceStr, out int Price);
            var updatedProduct = new AddProduct() { Name = Name, Description = Description, Price = Price };
            await updateProductRequest(ProductId, updatedProduct);
        }


        public async Task updateProductRequest(int productId, AddProduct updatedProduct)
        {
            var response = await productService.UpdateProduct(productId, updatedProduct);
            Console.WriteLine(response);
            await init();
        }

        public async Task deleteProduct()
        {
            await showProducts();
            Console.WriteLine("Select Product to Delete by Id :");
            var prod = Console.ReadLine();
            var output = int.TryParse(prod, out int ProductId);
            var response = await productService.DeleteProduct(ProductId);
            Console.WriteLine(response);
        }
        */
    }
}
