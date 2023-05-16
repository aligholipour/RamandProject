using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ramand.Application.Contracts;

namespace Ramand.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/customers")]
    [ApiVersion("2.0")]
    public class UserControllerV2 : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserControllerV2(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }
    }
}
