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

        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Book CreateOneBook(Book book)
        { 
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            _manager.Book.CreateOneBook(book);
              _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _manager.Book.DeleteOneBook(entity);
                _manager.Save();


        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetBookById(int id, bool tracChanges)
        {
            return _manager.Book.GetOneBookById(id, tracChanges);
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity == null)
                throw new Exception($"Book eith id: {id} coudnt found.");
     
                entity.Title = book.Title;  
                entity.Price = book.Price;
             _manager.Save();


        }
    }
}
