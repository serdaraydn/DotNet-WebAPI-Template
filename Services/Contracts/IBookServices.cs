using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Contracts
{
    public interface IBookServices
    {
        IEnumerable<BookDTO> GetAllBooks( bool trackChanges);
        Book GetBookById(int id, bool tracChanges);
        Book CreateOneBook(Book book);
        void DeleteOneBook(int id ,bool trackChanges);
        void UpdateOneBook(int id ,BookDTOForUpdates bookDTO, bool trackChanges);
    }
}
