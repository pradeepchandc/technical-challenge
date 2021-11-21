using BookCart.Application.Books.Commands.CreateBook;
using BookCart.Application.Books.Commands.UpdateBook;
using BookCart.Application.Common.Exceptions;
using BookCart.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Books.Commands;

using static Testing;
public class UpdateBookTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new UpdateBookCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireValidBook()
    {
        var command = new UpdateBookCommand { Id = -1 };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateBook()
    {

        var createCommand = new CreateBookCommand
        {
            Title = "Title 1",
            Author = "Author 1",
            CoverImage = "Image 1",
            Description = "Description 1",
            Price = 100
        };

        var bookId = await SendAsync(createCommand);


        var command = new UpdateBookCommand
        {
            Id = bookId,
            Title = "Updated Book Title"
        };

        await SendAsync(command);

        var book = await FindAsync<Book>(bookId);

        book.Should().NotBeNull();
        book!.Title.Should().Be(command.Title);
    }
}
