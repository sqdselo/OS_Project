using Microsoft.AspNetCore.Mvc;
using OnlineChats.Domain.Interfaces;
using OnlineChats.Domain.Models;

namespace OnlineChats.API.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //создание пользователя [post]
        //получение одного пользователя [get]
        //получение всех пользователей [get]

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _userService.CreateUser(user);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUser(username);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

    }
}
