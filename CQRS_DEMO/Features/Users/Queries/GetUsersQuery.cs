using CQRS_DEMO.DTOS;
using MediatR;
namespace CQRS_DEMO.Features.Users.Queries
{
    public class GetUsersQuery :IRequest<IEnumerable<UserDto>>
    {

    }
}
