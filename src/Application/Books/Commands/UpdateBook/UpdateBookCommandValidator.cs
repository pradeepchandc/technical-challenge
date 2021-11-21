using BookCart.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookCart.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBookCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(b => b.Id)
           .NotEmpty();
        RuleFor(b => b.Title)
            .MaximumLength(100)
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        RuleFor(b => b.Description)
            .MaximumLength(500);
        RuleFor(b => b.CoverImage)
            .MaximumLength(200);
        RuleFor(b => b.Author)
            .MaximumLength(100);
    }

    public async Task<bool> BeUniqueTitle(UpdateBookCommand command, string title, CancellationToken cancellationToken)
    {
        return !await _context.Books
            .AnyAsync(l => l.Id != command.Id &&  l.Title == title, cancellationToken);
    }
}
