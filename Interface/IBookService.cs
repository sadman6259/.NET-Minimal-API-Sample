using Minimal_API_Prac.Model;

namespace Minimal_API_Prac.Interface
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();

        Book GetBook(int id);

        Book AddBook(Book book);

        Book UpdateBook(int id, Book updatedBook);

        int DeleteBook(int id);
    }
}
