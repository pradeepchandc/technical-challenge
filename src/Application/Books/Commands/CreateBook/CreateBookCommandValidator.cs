using BookCart.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookCart.Application.Books.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Handles the validation logic for Create book command using fluent validation
    /// </summary>
    public CreateBookCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(b => b.Title)
            .MaximumLength(100)
            .NotEmpty()
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        RuleFor(b => b.Description)
            .MaximumLength(500)
            .NotEmpty();
        RuleFor(b => b.CoverImage)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(b => b.Author)
            .MaximumLength(100)
            .NotEmpty();
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Books
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
