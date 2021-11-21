using BookCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BookCart.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Book> Books { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
