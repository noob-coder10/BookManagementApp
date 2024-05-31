using AutoMapper;
using BookManagementApp.Models.Domain;
using BookManagementApp.Models.DTO;

namespace BookManagementApp.Mappings
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Book, BookDto>().ForMember(x => x.BookTitle, y => y.MapFrom(z => z.Title))
                                      .ForMember(x => x.BookAuthor, y => y.MapFrom(z => z.Author))
                                      .ForMember(x => x.BookPublishedDate, y => y.MapFrom(z => z.PublishedDate))
                                      .ForMember(x => x.BookGenre, y => y.MapFrom(z => z.Genre))
                                      .ReverseMap();
            
            CreateMap<Book, AddBookRequestDto>().ForMember(x => x.BookTitle, y => y.MapFrom(z => z.Title))
                                      .ForMember(x => x.BookAuthor, y => y.MapFrom(z => z.Author))
                                      .ForMember(x => x.BookPublishedDate, y => y.MapFrom(z => z.PublishedDate))
                                      .ForMember(x => x.BookGenre, y => y.MapFrom(z => z.Genre))
                                      .ReverseMap();
            
            CreateMap<Book, UpdateBookRequestDto>().ForMember(x => x.BookTitleToBeUpdated, y => y.MapFrom(z => z.Title))
                                      .ForMember(x => x.BookAuthorToBeUpdated, y => y.MapFrom(z => z.Author))
                                      .ForMember(x => x.BookPublishedDateToBeUpdated, y => y.MapFrom(z => z.PublishedDate))
                                      .ForMember(x => x.BookGenreToBeUpdated, y => y.MapFrom(z => z.Genre))
                                      .ReverseMap();

            CreateMap<Book, DeletedBookDto>().ForMember(x => x.DeletedBookId, y => y.MapFrom(z => z.BookId))
                                      .ForMember(x => x.DeletedBookTitle, y => y.MapFrom(z => z.Title))
                                      .ReverseMap();
        }
    }
}
