using BookCart.Domain.Entities;

namespace BookCart.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seed, if necessary
        if (!context.Books.Any())
        {
            await context.Books.AddRangeAsync(new List<Book>
            { 
                new Book{
                    Author = "Paulo Coelho",
                    CoverImage = "Cover Image 1",
                    Description = "A magical fable about following your dream",
                    Title = "Alchemist",
                    Price = 499.99M
                },
                new Book{
                Author = "Dan Brown",
                CoverImage = "Cover Image 2",
                Description = "The Da Vinci Code : Mystery thriller",
                Title = "The Da Vinci Code",
                Price = 499.99M
            }
            });

            await context.SaveChangesAsync();
        }
    }
}
