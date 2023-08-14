using Homework2.DB;
using Homework2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private static List<Book> Books = new List<Book>
        {
            new Book { Author = "Корнеј Чуковски", Title = "Доктор Офболи" },
            new Book { Author = "Оливера Николова", Title = "Зоки Поки" },
            new Book { Author = "Петре М. Андреевски", Title = "Касни Порасни"}
        };

        [HttpGet("GetBooks")]
        public IActionResult GetBooks()
        {
            try
            {
                return Ok(Books);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }

        [HttpGet("GetBookByIndex/{index}")]
        public IActionResult GetBookByIndex(int index)
        {
            try
            {
                if (index >= 0 && index < Books.Count)
                {
                    return Ok(Books[index]);
                }
                return NotFound("Book not found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }

        [HttpGet("GetBookByAuthorAndTitle")] //https://localhost:[port]/api/books/GetBookByAuthorAndTitle?author=Корнеј Чуковски&title=Доктор Офболи
        public IActionResult GetBookByAuthorAndTitle([FromQuery] string author, [FromQuery] string title)
        {
            try
            {
                var book = Books.FirstOrDefault(x => x.Author == author && x.Title == title);
                if (book != null)
                {
                    return Ok(book);
                }
                return NotFound("Book not found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book Added");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }

        [HttpPost("GetBookTitles")]
        public IActionResult GetBookTitles([FromBody] List<Book> books)
        {
            try
            {
                var titles = books.Select(x => x.Title).ToList();
                return Ok(titles);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }
    

    }
}
