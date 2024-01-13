using AutoMapper;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Dtos.Borrowing;
using LibraNet.Contracts.Entities;


namespace LibraNet.Services.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Borrowing, BorrowingDto>();

            CreateMap<BookCreateDto, Book > ();
            CreateMap<BorrowingCreateDto, Borrowing>();

            CreateMap<BookUpdateDto, Book>();
            CreateMap<BorrowingUpdateDto, Borrowing>();

        }
    }
}
