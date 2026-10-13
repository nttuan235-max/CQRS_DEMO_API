using CQRS_DEMO.DTOS;
using MediatR;

namespace CQRS_DEMO.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>

    {
        public string UserID { get; set; }
    }
}
