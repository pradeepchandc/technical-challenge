using BookCart.Application.Books.Commands.CreateBook;
using BookCart.Application.Books.Commands.DeleteBook;
using BookCart.Application.Common.Exceptions;
using BookCart.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace API.IntegrationTests.Books.Commands;

using static Testing;
internal class DeleteBookTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new DeleteBookCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireValidBookId()
    {
        var command = new DeleteBookCommand { Id = -1 };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteBook()
    {
        //Create a book
        var command = new CreateBookCommand
        {
            Title = "Title 1",
            Author = "Author 1",
            CoverImage = "Image 1",
            Description = "Description 1",
            Price = 100
        };

        var bookId = await SendAsync(command);

        //delete the book
        await SendAsync(new DeleteBookCommand
        {
            Id = bookId
        });

        var book = await FindAsync<Book>(bookId);

        //If delete is success book should be null
        book.Should().BeNull();
    }
}
