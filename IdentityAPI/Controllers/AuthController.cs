using Identity.Application.Configurations.Interfaces;
using Identity.Application.Dtos.User;
using Identity.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> LoginAsync(UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            UserLoginResponse userLoginResponse = await _userService.LoginAsync(request);

            if (userLoginResponse.ErrorCode == LoginErrorCode.NotFound)
            {
                return BadRequest(userLoginResponse);
            }

            return Ok(userLoginResponse);
        }
    }
}