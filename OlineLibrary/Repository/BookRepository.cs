using Microsoft.EntityFrameworkCore;
using OlineLibrary.Data;
using OlineLibrary.Model;

namespace OlineLibrary.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly OnlineLibraryContext _context;
        public BookRepository(OnlineLibraryContext context)
        {
            _context = context;
        }
        public async Task<BookModel> GetBookByISBN(string ISBN)
        {
            var record = await _context.Books.Where(x => x.Isbn == ISBN).Select(x => new BookModel()
            {
                Isbn = x.Isbn,
                Title = x.Title,
                Category = x.Category,
                RackNumber = x.RackNumber,
                Price = x.Price,
                StockNumber = x.StockNumber

            }).FirstOrDefaultAsync();
            return record;
        }
    }
    
}
