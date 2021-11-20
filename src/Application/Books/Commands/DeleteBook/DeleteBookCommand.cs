using BookCart.Application.Common.Exceptions;
using BookCart.Application.Common.Interfaces;
using BookCart.Domain.Entities;
using MediatR;

namespace BookCart.Application.Books.Commands.DeleteBook;

public class DeleteBookCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBookCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (book == null)
        {
            throw new NotFoundException(nameof(Book), request.Id);
        }

        _context.Books.Remove(book);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
