using AutoMapper;
using LibraryMvc.Models;
using LibraryMvc.DTOs;

namespace LibraryMvc.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Book
            CreateMap<Book, BookReadDto>()
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthor.Select(ba => ba.Author)));

            CreateMap<BookCreateDto, Book>().ForMember(dest => dest.BookAuthor, opt => opt.Ignore());
            CreateMap<BookUpdateDto, Book>().ForMember(dest => dest.BookAuthor, opt => opt.Ignore());

            // Author
            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();

            // Publisher
            CreateMap<Publisher, PublisherReadDto>();
            CreateMap<PublisherCreateDto, Publisher>();
            CreateMap<PublisherUpdateDto, Publisher>();
        }
    }
}

