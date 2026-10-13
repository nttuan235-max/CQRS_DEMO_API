using System;
using MediatR;
using CQRS_DEMO.DTOS;
using CQRS_DEMO.Models;
using AutoMapper;
namespace CQRS_DEMO.Features.Users.Queries
{
    public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<UserDto> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            // Giả lập dữ liệu User lấy từ database
            var user = new user
            {
                UserID = request.UserID,
                mail = "test@gmail.com",
                name = "Test User"
            };

            // User → UserDto bằng AutoMapper
            var userDto = _mapper.Map<UserDto>(user);

            return Task.FromResult(userDto);
        }
    }
    
}
