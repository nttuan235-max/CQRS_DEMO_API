using FluentValidation;
namespace CQRS_DEMO.Features.Users.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserID)
                .NotEmpty().WithMessage("User ID is required.")
                .MaximumLength(50).WithMessage("User ID cannot exceed 50 characters.");

            RuleFor(x => x.mail)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            
        }
    }
}
