using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookCart.Application.Common.Interfaces;
using BookCart.Application.Common.Mappings;
using BookCart.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookCart.Application.Books.Queries.ListBooks
{
    public class ListBooksQuery : IRequest<PaginatedList<BookDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class ListBooksQueryHandler : IRequestHandler<ListBooksQuery, PaginatedList<BookDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ListBooksQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<BookDto>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            //Gets the list of books with pagination 
            var books = await _context.Books
                        .AsNoTracking()
                        //Automapper maps Book to BookDto
                        .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                        .OrderBy(t => t.Title)
                        .PaginatedListAsync(request.PageNumber, request.PageSize);
            return books;

        }
    }
}
