namespace Rs.Application.Features.Blogs.CommandHandlers.AddBlog;

public class AddBlogCommandValidator: AbstractValidator<AddBlogCommand>
{
    public AddBlogCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(5).WithMessage("Title must be at least 5 characters long.")
            .MaximumLength(40).WithMessage("Title must not exceed 100 characters.");
        
        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters long.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}