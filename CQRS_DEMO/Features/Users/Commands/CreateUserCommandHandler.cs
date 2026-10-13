using MediatR;
namespace CQRS_DEMO.Features.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,string>
    {
        public Task <string> Handle
        (CreateUserCommand request,
            CancellationToken cancellationToken
            )
        {
            string message = $"User with ID {request.UserID} and email {request.mail} has been created successfully.";

            return Task.FromResult(message);
        }
    }
}
