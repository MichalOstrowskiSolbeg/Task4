using AutoMapper;
using RepositoryLayer.Models;
using ServiceLayer.DTO.Requests;
using ServiceLayer.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookCategoryRequest, BookCategory>()
                .ForMember(x => x.WhenAdded, y => y.MapFrom(s => DateTime.Now));

            CreateMap<BookCategory, BookCategoryResponse>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.CategoryText))
                .ForMember(x => x.Title, y => y.MapFrom(s => s.Book.Title));

            CreateMap<Book, BookResponse>()
                .ForMember(x => x.Authors, y => y.MapFrom(s => s.BookAuthors.Select(x => x.Author.FirstName + " " + x.Author.LastName).ToList()));
        }
    }
}