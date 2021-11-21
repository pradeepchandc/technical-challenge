using BookCart.Application.Common.Interfaces;
using BookCart.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookCart.Application.Books.Commands.CreateBook
{
    /// <summary>
    /// DTO object for create book object
    /// </summary>
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Business logic to save book details
    /// </summary>
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger _logger;
        public CreateBookCommandHandler(IApplicationDbContext context, ILogger<CreateBookCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }
            var book = new Book
            {
                Author = request.Author,
                CoverImage = request.CoverImage,
                Description = request.Description,
                Title = request.Title,
                Price = request.Price
            };

            //Add the book model to the dbContext
            await _context.Books.AddAsync(book, cancellationToken);

            //Create a book entry in the DB
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Created book: {Id}", book.Id);

            return book.Id;
        }
    }
}