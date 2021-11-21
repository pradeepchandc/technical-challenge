using BookCart.Application.Books.Queries.ListBooks;
using BookCart.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Books.Queries;
using static Testing;

public class ListBookTests : TestBase
{

    [Test]
    public async Task ShouldReturnBooks()
    {
        var alchemist = new Book
        {
            Author = "Paulo Coelho",
            CoverImage = "Cover Image 1",
            Description = "A magical fable about following your dream",
            Title = "Alchemist",
            Price = 499.99M
        };

        var daVinciCode = new Book
        {
            Author = "Dan Brown",
            CoverImage = "Cover Image 2",
            Description = "The Da Vinci Code : Mystery thriller",
            Title = "The Da Vinci Code",
            Price = 499.99M
        };

        await AddAsync(alchemist);
        await AddAsync(daVinciCode);

        var query = new ListBooksQuery
        {
            PageNumber = 1,
            PageSize = 1
        };

        var result = await SendAsync(query);

        result.TotalCount.Should().Be(2);
        result.TotalPages.Should().Be(2);
        result.HasNextPage.Should().Be(true);
        result.Items.First().Title.Should().Be(alchemist.Title); ;
    }
}
