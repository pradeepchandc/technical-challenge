﻿using BookCart.Application.Books.Commands.CreateBook;
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

        var bookId = await SendAsync(command);

        var book = await FindAsync<Book>(bookId);

        book.Should().NotBeNull();
        book!.Title.Should().Be(command.Title);
        book.Author.Should().Be(command.Author);
        book.Price.Should().Be(command.Price);
        book.LastModifiedBy.Should().BeNull();
        book.LastModified.Should().BeNull();
    }
}
