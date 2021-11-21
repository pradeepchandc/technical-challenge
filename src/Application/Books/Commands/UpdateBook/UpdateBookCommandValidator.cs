using FluentValidation;

namespace BookCart.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(b => b.Id)
           .NotEmpty();
        RuleFor(b => b.Title)
            .MaximumLength(100);
        RuleFor(b => b.Description)
            .MaximumLength(500);
        RuleFor(b => b.CoverImage)
            .MaximumLength(200);
        RuleFor(b => b.Author)
            .MaximumLength(100);
    }
}
