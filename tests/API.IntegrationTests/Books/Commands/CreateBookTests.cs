using BookCart.Application.Books.Commands.CreateBook;
using BookCart.Application.Common.Exceptions;
using BookCart.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace API.IntegrationTests.Books.Commands;

using static Testing;

public class CreateBookTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateBookCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateBook()
    {

        var command = new CreateBookCommand
        {
            Title = "Title 1",
            Author = "Author 1",
            CoverImage = "Image 1",
            Description = "Description 1",
            Price = 100
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<Book>(itemId);

        item.Should().NotBeNull();
        item!.Title.Should().Be(command.Title);
        item.Author.Should().Be(command.Author);
        item.Price.Should().Be(command.Price);
        item.LastModifiedBy.Should().BeNull();
        item.LastModified.Should().BeNull();
    }
}
