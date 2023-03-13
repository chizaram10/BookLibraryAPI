using BookLibraryAPI.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace BookLibraryAPI.InfraStructure
{
    public class BookLibraryInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookLibraryContext>();

                context.Database.EnsureCreated();

                if (!context.Books.Any())
                {
                    string fileName = Path.Combine(Directory.GetParent(Environment.CurrentDirectory)
                        .ToString(), "BookLibraryAPI.InfraStructure", "db", "books.json");
                    var read = File.ReadAllText(fileName);
                    var data = JsonSerializer.Deserialize<List<Book>>(read)!;
                    foreach (var item in data)
                        context.Books.AddRange(item);
                    context.SaveChanges();
                }
            }
        }
    }
}
