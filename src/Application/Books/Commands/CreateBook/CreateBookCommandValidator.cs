using FluentValidation;

namespace BookCart.Application.Books.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    /// <summary>
    /// Handles the validation logic for Create book command using fluent validation
    /// </summary>
    public CreateBookCommandValidator()
    {
        RuleFor(b => b.Title)
            .MaximumLength(100)
            .NotEmpty();
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
}
