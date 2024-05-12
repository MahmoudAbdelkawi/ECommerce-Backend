using AutoMapper;
using ECommerce.Core.Features.UserProfile.Query.Dtos;
using ECommerce.Core.Mapper.MapperDtos;
using ECommerce.Core.Response;
using ECommerce.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.UserProfile.Query.Handlers
{
    public class UserProfileQueryHandler :
        IRequestHandler<GetMeDto, ApiResponse<UserDto>>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserDto>> Handle(GetMeDto request, CancellationToken cancellationToken)
        {
            var user = await _userProfileRepository.GetUserAsync();

            var userResponse = _mapper.Map<UserDto>(user);

            return new ApiResponse<UserDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "User found",
                Success = true,
                Data = userResponse
            };
        }
    }
}
