using BookCart.Application.Common.Exceptions;
using BookCart.Application.Common.Interfaces;
using BookCart.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookCart.Application.Books.Commands.DeleteBook;

public class DeleteBookCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger _logger;

    public DeleteBookCommandHandler(IApplicationDbContext context, ILogger<DeleteBookCommand> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var book = await _context.Books
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (book == null)
        {
            throw new NotFoundException(nameof(Book), request.Id);
        }

        _context.Books.Remove(book);

        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Deleted book: {Id}", book.Id);

        return Unit.Value;
    }
}
