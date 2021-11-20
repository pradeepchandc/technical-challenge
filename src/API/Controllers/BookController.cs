using BookCart.Application.Books.Commands.CreateBook;
using BookCart.Application.Books.Commands.DeleteBook;
using BookCart.Application.Books.Commands.UpdateBook;
using Microsoft.AspNetCore.Mvc;

namespace BookCart.API.Controllers;
public class BookController : ApiControllerBase
{
    // GET: api/<BookController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<BookController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    /// <summary>
    /// Create book 
    /// </summary>
    /// <param name="command">Book details object</param>
    /// <returns>Book Id</returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBookCommand command)
    {
        //Calls the business logic handler using mediator
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Update book details
    /// </summary>
    /// <param name="request">Book details</param>
    [HttpPut()]
    public async Task<ActionResult> Update([FromBody] UpdateBookCommand request)
    {
        //Calls the business logic handler using mediator
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
        //Calls the business logic handler using mediator
        await Mediator.Send(new DeleteBookCommand { Id = id });

        return NoContent();
    }
}
