using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookServices
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public Book CreateOneBook(Book book)
        { 
            _manager.Book.CreateOneBook(book);
              _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity == null)
            {
                _logger.logInfo($"Book with id: {id} coudnt found.");
                throw new ArgumentNullException(nameof(entity));
            }
                
            _manager.Book.DeleteOneBook(entity);
                _manager.Save();


        }

        public IEnumerable<BookDTO> GetAllBooks(bool trackChanges)
        {
            var books= _manager.Book.GetAllBooks(trackChanges);
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public Book GetBookById(int id, bool tracChanges)
        {
            var book= _manager.Book.GetOneBookById(id, tracChanges);
            if (book == null)
            {
                throw new BookNotFoundException(id);
            }
            return book;
        }

        public void UpdateOneBook(int id, BookDTOForUpdates bookDTO, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity == null)
            {
                throw new BookNotFoundException(id);
            }

                //entity.Title = book.Title;  
                //entity.Price = book.Price;
               entity = _mapper.Map(bookDTO, entity);
            _manager.Save();

        }
    }
}
