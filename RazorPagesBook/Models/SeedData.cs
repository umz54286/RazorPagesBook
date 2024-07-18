using Microsoft.EntityFrameworkCore;
using RazorPagesBook.Data;

namespace RazorPagesBook.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesBookContext>>()))
            {
                if (context == null || context.Book == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // If there are any data in the database, the seed initializer returns and no books are added.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        ProductNo = "x001",
                        ProductName = "Book1",
                        Price = 1,
                        PublicationDate = DateTime.Parse("1911-1-1")
                    },

                    new Book
                    {
                        ProductNo = "x002",
                        ProductName = "Book2",
                        Price = 1,
                        PublicationDate = DateTime.Parse("1911-1-1")
                    },

                    new Book
                    {
                        ProductNo = "x003",
                        ProductName = "Book3",
                        Price = 1,
                        PublicationDate = DateTime.Parse("1911-1-1")
                    },

                    new Book
                    {
                        ProductNo = "x004",
                        ProductName = "Book4",
                        Price = 1,
                        PublicationDate = DateTime.Parse("1911-1-1")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
