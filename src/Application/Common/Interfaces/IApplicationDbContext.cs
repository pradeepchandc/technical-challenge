using BookCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCart.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Book> Books { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
