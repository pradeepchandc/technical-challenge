using BookCart.Application.Books.Queries.GetBook;
using BookCart.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace API.IntegrationTests.Books.Queries
{
    using static Testing;

    public class GetBookTests : TestBase
    {

        [Test]
        public async Task ShouldReturnBook()
        {
            var book = new Book
            {
                Author = "Paulo Coelho",
                CoverImage = "Cover Image 1",
                Description = "A magical fable about following your dream",
                Title = "Alchemist",
                Price = 499.99M
            };
            await AddAsync(book);

            var query = new GetBookQuery { Id = book.Id };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result!.Title.Should().Be(book.Title);
            result.Author.Should().Be(book.Author);
            result.Price.Should().Be(book.Price); ;
        }
    }
}