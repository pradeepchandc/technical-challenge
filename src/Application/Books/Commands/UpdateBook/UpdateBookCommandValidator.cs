using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BookCart.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
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
