using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCart.Application.Common.Exceptions;
using BookCart.Application.Common.Interfaces;
using BookCart.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookCart.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger _logger;

        public UpdateBookCommandHandler(IApplicationDbContext context, ILogger<UpdateBookCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
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

            book.Price = request.Price;
            book.Title = request.Title;
            book.Description = request.Description;
            book.Author = request.Author;
            book.CoverImage = request.CoverImage;

            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Updated book: {Id}", book.Id);
            return Unit.Value;
        }
    }
}