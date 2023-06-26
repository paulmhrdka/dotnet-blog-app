using FluentValidation;

namespace dotnet_clean_arch.Application.BlogItems.Commands.CreateBlogItem;

public class CreateBlogItemCommandValidator : AbstractValidator<CreateBlogItemCommand>
{
    public CreateBlogItemCommandValidator()
    {
        RuleFor(i => i.Title).MinimumLength(3).NotEmpty();
        RuleFor(i => i.Content).MinimumLength(5).NotEmpty();
    }
}