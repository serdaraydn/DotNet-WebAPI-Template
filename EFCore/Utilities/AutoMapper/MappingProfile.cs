using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace EFCore.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDTOForUpdates,Book>();
                CreateMap<Book, BookDTO>();
        }
    }
}
