using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookCart.Application.Common.Interfaces;
using BookCart.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookCart.Application.Books.Queries.GetBook
{
    public class GetBookQuery : IRequest<BookDto>
    {
        public int Id { get; set; }
    }

    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            var book = await _context.Books
                        .AsNoTracking()
                        .Where(x => x.Id == request.Id)
                        .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(cancellationToken);

            return book;

        }
    }
}
