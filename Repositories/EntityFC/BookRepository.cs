using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EntityFC
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOneBook(Book book)=> Create(book);

        public void DeleteOneBook(Book book)=> Delete(book);


        public IQueryable<Book> GetAllBooks(bool trackChanges)=> FindAll(trackChanges);


        public Book GetOneBookById(int id, bool trackChanges)=> FindByCondition(book => book.Id.Equals(id), trackChanges).SingleOrDefault();


        public void UpdateOneBook(Book book)=> Update(book);

    }
}
