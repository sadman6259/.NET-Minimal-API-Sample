using Minimal_API_Prac.DB;
using Minimal_API_Prac.Interface;
using Minimal_API_Prac.Model;

namespace Minimal_API_Prac.Service
{
    public class BookService : IBookService
    {
        private BookDB dB;
        public BookService(BookDB _db)
        {
            this.dB = _db;
        }

        public async Task<List<Book>> GetBooks()
        {
            var myTask = Task.Run(() =>  dB.bookDBs.ToList());
            List<Book> result = await myTask;
            return result;
        }

        public Book GetBook(int id)
        {
            return dB.bookDBs.FirstOrDefault(x => x.Id == id);
        }

        public Book AddBook(Book book)
        {
            dB.bookDBs.Add(book);
            dB.SaveChanges();
            return book;
        }

        public Book UpdateBook(int id, Book updatedBook)
        {
            var existingBook = dB.bookDBs.FirstOrDefault(x => x.Id == id);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
            }
            dB.SaveChanges();
            return updatedBook;
        }

        public int DeleteBook(int id)
        {
            var bookToRemove = dB.bookDBs.FirstOrDefault(x => x.Id == id);
            if (bookToRemove != null)
            {
                dB.bookDBs.Remove(bookToRemove);
            }
            dB.SaveChanges();
            return id;
        }
    }

}
