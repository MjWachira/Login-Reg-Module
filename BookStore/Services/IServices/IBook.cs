using BooksModels;

namespace BookStore.Services.IServices
{
    public interface IBook
    {
        Task<List<Book>> GetBooksAsync();

        Task<Book> GetBookByIdAsync(int id);

        Task<string> AddBook(AddBook newBook);

        Task<string> UpdateBook(int id, AddBook updatedBook);

        Task<string> DeleteBook(int id);
    }
}
