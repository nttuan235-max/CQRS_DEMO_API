using MediatR;
namespace CQRS_DEMO.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string UserID { get; set; }
        public string mail { get; set; }
    }
}
