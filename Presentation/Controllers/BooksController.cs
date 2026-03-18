using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
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
                var books = _manager.BookServices.GetAllBooks(false);
                return Ok(books);           
        }

        [HttpGet("{id}")]
        public IActionResult GetBook([FromRoute] int id)
        {   
                var book = _manager.BookServices.GetBookById(id, false);
                return Ok(book);    
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Entities.Models.Book book)
        {
            
                if (book == null)
                {
                    return BadRequest("Book data is null.");
                }
                _manager.BookServices.CreateOneBook(book);
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute] int id, [FromBody] BookDTOForUpdates BookDTO)
        {
 
                _manager.BookServices.UpdateOneBook(id, BookDTO, true);
                return NoContent();       
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
           
                _manager.BookServices.DeleteOneBook(id, true);

                return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBook([FromRoute] int id, [FromBody] Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Book> patchDoc)
        {
               var book = _manager.BookServices.GetBookById(id, true);           
                patchDoc.ApplyTo(book, ModelState);              
                _manager.BookServices.UpdateOneBook(id, new BookDTOForUpdates(book.Id,book.Title,book.Price), true);
                
                return NoContent();
 
        }
    }
}
