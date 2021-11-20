using FluentValidation;

namespace BookCart.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(b => b.Id)
            .NotEmpty();
    }
}
