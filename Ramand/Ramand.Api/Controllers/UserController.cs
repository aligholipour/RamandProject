using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramand.Api.Models;
using Ramand.Application.Contracts;
using Ramand.Domain.Contracts;
using Ramand.Domain.Entities;

namespace Ramand.Api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v{version:apiVersion}/customers")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IJwtService jwtService, SignInManager<User> signInManager, IUserRepository userRepository, IUserService userService)
        {
            _jwtService = jwtService;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(userModel.Username, userModel.Password, false, false);

            if (result.Succeeded)
            {
                var generatedJwt = _jwtService.GenerateJwt(userModel.Username);

                return Ok(new { Token = generatedJwt });
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("SendUserDetailToQueue")]
        public async Task<ActionResult> SendUserDetailToQueue()
        {
            var user = await _userRepository.GetFirstUser();

            if (user is not null)
            {
                _userService.SendUserToQueue(user);

                return Ok("User sent");
            }

            return BadRequest();
        }
    }
}