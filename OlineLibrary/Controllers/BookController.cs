using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlineLibrary.Repository;

namespace OlineLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet("{isbn}")]
        public async Task<IActionResult> GetBookbyISBN([FromRoute] string isbn) {
            var book = await _bookRepository.GetBookByISBN(isbn);
            return Ok(book);

            }

    }
}
