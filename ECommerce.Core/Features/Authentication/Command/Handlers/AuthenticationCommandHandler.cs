using AutoMapper;
using ECommerce.Core.Features.Authentication.Command.Dtos;
using ECommerce.Core.Response;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using MediatR;
using System.Net;

namespace ECommerce.Core.Features.Authentication.Command.Handlers
{
    public class AuthenticationCommandHandler
        : IRequestHandler<SignupDto, ApiResponse<string>>,
        IRequestHandler<LoginDto, ApiResponse<string>>,
        IRequestHandler<ForgetPasswordDto, ApiResponse<string>>,
        IRequestHandler<ActivationCodeDto, ApiResponse<string>>,
        IRequestHandler<ChangePasswordDto, ApiResponse<string>>
    {
        private readonly IAuthenticationRepository _authenticationRespoitory;
        private readonly IMapper _mapper;

        public AuthenticationCommandHandler(IAuthenticationRepository authenticationRespoitory, IMapper mapper)
        {
            _authenticationRespoitory = authenticationRespoitory;
            _mapper = mapper;
        }

        public async Task<ApiResponse<string>> Handle(SignupDto request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var userByEmail = await _authenticationRespoitory.FindByEmail(request.Email);
            if (userByEmail is not null)
            {
                return new ApiResponse<string>
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Message = "Email already exist",
                    Success = false
                };
            }

            var userByUserName = await _authenticationRespoitory.FindByUserName(request.UserName);
            if (userByUserName is not null)
            {
                return new ApiResponse<string>
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Message = "UserName already exist",
                    Success = false
                };
            }

            var result = await _authenticationRespoitory.Signup(user, request.Password);

            return new ApiResponse<string>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "User created successfully",
                Success = true,
                Data = result
            };
        }

        public async Task<ApiResponse<string>> Handle(LoginDto request, CancellationToken cancellationToken)
        {
            var result = await _authenticationRespoitory.Login(request.Email, request.Password);
            if (result is null)
            {
                return new ApiResponse<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Error in email or password",
                    Success = false
                };
            }

            return new ApiResponse<string>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "User logged in successfully",
                Success = true,
                Data = result
            };
        }

        public async Task<ApiResponse<string>> Handle(ForgetPasswordDto request, CancellationToken cancellationToken)
        {
            var user = await _authenticationRespoitory.FindByEmail(request.Email);
            if (user is null)
            {
                return new ApiResponse<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "User not found",
                    Success = false
                };
            }

            await _authenticationRespoitory.ForgetPassword(request.Email);
            return new ApiResponse<string>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Code sent to your email",
                Success = true
            };
        }

        public async Task<ApiResponse<string>> Handle(ChangePasswordDto request, CancellationToken cancellationToken)
        {
            var user = await _authenticationRespoitory.FindByEmail(request.Email);
            if (user is null)
            {
                return new ApiResponse<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "User not found",
                    Success = false
                };
            }

            await _authenticationRespoitory.ChangePassword(request.Email, request.NewPassword);
            return new ApiResponse<string>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Done",
                Success = true
            };
        }

        public async Task<ApiResponse<string>> Handle(ActivationCodeDto request, CancellationToken cancellationToken)
        {
            var result = await _authenticationRespoitory.ActivationCode(request.Email, request.ActivationCode);
            if (!result)
            {
                return new ApiResponse<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Code is not valid",
                    Success = false
                };
            }

            return new ApiResponse<string>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Code is valid",
                Success = true
            };
        }
    }
}
