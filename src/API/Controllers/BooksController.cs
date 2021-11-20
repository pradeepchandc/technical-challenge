using BookCart.Application.Books.Commands.CreateBook;
using BookCart.Application.Books.Commands.DeleteBook;
using BookCart.Application.Books.Commands.UpdateBook;
using BookCart.Application.Books.Queries.GetBook;
using BookCart.Application.Books.Queries.ListBooks;
using BookCart.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCart.API.Controllers;
public class BooksController : ApiControllerBase
{
    
    /// <summary>
    /// Get book deatails
    /// </summary>
    /// <param name="id">Book Id</param>
    /// <returns>Book details</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> Get(int id)
    {
        //Calls the business logic handler using mediator
        return await Mediator.Send(new GetBookQuery { Id = id });
    }

    /// <summary>
    /// List the books with pagination.
    /// </summary>
    /// <param name="query">Page number and page size</param>
    /// <returns>Paginated list of books</returns>
    [HttpGet()]
    public async Task<ActionResult<PaginatedList<BookDto>>> ListBooks([FromQuery] ListBooksQuery query)
    {
        return await Mediator.Send(query);
    }

    /// <summary>
    /// Create book 
    /// </summary>
    /// <param name="command">Book details object</param>
    /// <returns>Book Id</returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBookCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Update book details
    /// </summary>
    /// <param name="request">Book details</param>
    [HttpPut()]
    public async Task<ActionResult> Update([FromBody] UpdateBookCommand request)
    {
        await Mediator.Send(request);

        return NoContent();
    }

    /// <summary>
    /// Delete book by Id 
    /// </summary>
    /// <param name="id">Book Id</param>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteBookCommand { Id = id });

        return NoContent();
    }
}
