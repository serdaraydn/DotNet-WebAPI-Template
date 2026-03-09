using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {

            try
            {
                var books = _manager.BookServices.GetAllBooks(false);
                return Ok(books);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetBook([FromRoute] int id)
        {


            try
            {
                var book = _manager.BookServices.GetBookById(id, false);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Entities.Models.Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Book data is null.");
                }
                _manager.BookServices.CreateOneBook(book);
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute] int id, [FromBody] Book Book)
        {
            try
            {

                if (Book == null)
                {
                    return BadRequest("Book data is null.");
                }

                _manager.BookServices.UpdateOneBook(id, Book, true);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            try
            {
                _manager.BookServices.DeleteOneBook(id, true);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBook([FromRoute] int id, [FromBody] Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Book> patchDoc)
        {
            try
            {
                var book = _manager.BookServices.GetBookById(id, true);

                if (book == null)
                {
                    return NotFound();
                }
                patchDoc.ApplyTo(book, ModelState);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _manager.BookServices.UpdateOneBook(id, book, true);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
