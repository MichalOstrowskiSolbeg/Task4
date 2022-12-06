using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookCategoryRepository, BookCategoryRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}