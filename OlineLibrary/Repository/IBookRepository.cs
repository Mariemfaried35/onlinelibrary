using OlineLibrary.Model;

namespace OlineLibrary.Repository
{
    public interface IBookRepository
    {
        Task<BookModel> GetBookByISBN(string ISBN);
    }
}
