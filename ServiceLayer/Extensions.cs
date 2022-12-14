using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class Extensions
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IBook, BookService>();
            services.AddTransient<IBookCategory, BookCategoryService>();
            services.AddTransient<ICategory, CategoryService>();
            return services;
        }
    }
}
