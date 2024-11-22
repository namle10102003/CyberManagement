using CyberManager.Api.Constracts.User;
using CyberManager.Application.Services.Users;
using CyberManager.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CyberManager.Api.Controllers;

[Route("user")]
public class UserController : ApiController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _userService.GetById(id);

        return Ok(_mapper.Map<UserResponse>(user));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = _mapper.Map<User>(request); 

        ErrorOr<UserResult> userResult = await _userService.Register(user);

        return userResult.Match(
            newUser => Ok(_mapper.Map<UserResponse>(newUser)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        ErrorOr<UserResult> userResult = await _userService.Login(request.UserName, request.Password);

        return userResult.Match(
            user => Ok(_mapper.Map<UserResponse>(user)),
            errors => Problem(errors)
        );
    }

    [HttpPut("deposit")]
    public async Task<IActionResult> Deposit(DepositRequest request)
    {
        ErrorOr<Updated> result = await _userService.DepositCredit(request.Id, request.Cash);

        return result.Match(
            updated => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpPut("updateCredit")]
    public async Task<IActionResult> UpdateCredit(DepositRequest request)
    {
        ErrorOr<Updated> result = await _userService.UpdateCredit(request.Id, request.Cash);

        return result.Match(
            updated => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpPut("changePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        ErrorOr<Updated> result = await _userService.ChangePassword(request.Id, request.Password);

        return result.Match(
            updated => Ok(),
            errors => Problem(errors)
        );
    }
}