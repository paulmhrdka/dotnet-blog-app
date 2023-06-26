using FluentValidation;

namespace dotnet_clean_arch.Application.BlogItems.Commands.UpdateBlogItem;

public class UpdateBlogItemCommandValidator : AbstractValidator<UpdateBlogItemCommand>
{
    public UpdateBlogItemCommandValidator()
    {
        RuleFor(i => i.Title).MinimumLength(3).NotEmpty();
        RuleFor(i => i.Content).MinimumLength(5).NotEmpty();
    }
}