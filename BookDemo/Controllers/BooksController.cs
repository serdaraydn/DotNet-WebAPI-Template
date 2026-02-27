using BookDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = Data.ApplicationContext.Books;
            return Ok(books);

        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var books = Data.ApplicationContext.Books.FirstOrDefault(b => b.Id == id);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);

        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Models.Book book)
        {

            try
            {
                if (book == null)
                {
                    return BadRequest();
                }
                Data.ApplicationContext.Books.Add(book);
                return CreatedAtAction(nameof(GetOneBook), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateBook([FromBody] Models.Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest();
                }
                var existingBook = Data.ApplicationContext.Books.FirstOrDefault(b => b.Id == book.Id);
                if (existingBook == null)
                {
                    return NotFound();
                }


                existingBook.Title = book.Title;
                existingBook.Price = book.Price;
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteBook()
        {
            ApplicationContext.Books.Clear();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = Data.ApplicationContext.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    return NotFound();
                }
                Data.ApplicationContext.Books.Remove(book);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PatchBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument <Models.Book> book)
        {
            
                if (book == null)
                {
                    return BadRequest();
                }
                var existingBook = Data.ApplicationContext.Books.FirstOrDefault(b => b.Id == id);
                if (existingBook == null)
                {
                    return NotFound();
                }
                book.ApplyTo(existingBook, ModelState);
                return NoContent();
           
        }
    }
}
