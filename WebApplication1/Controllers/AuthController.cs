using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationRequest request) 
        {
            var user = _authService.Authenticate(request.Username, request.Password);

            if (user == null) 
            {
                return BadRequest(new {message = "Неверное имя пользователя или пароль"});
            }
            return Ok(new { 
                user.Id,
                user.Name,
                user.Surname,
                user.Patronymics,
                user.Email,
                user.Username, 
                user.Password
            });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegistrationRequest request) 
        {
            var newUser = new User
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                Patronymics = request.Patronumics,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password
            };
            var user = _authService.Register(newUser, request.Password);

            if (user == null) 
            {
                return BadRequest(new { message = "Имя пользователя уже занято"});
            }

            return Ok(new
            {
                user.Id,
                user.Name,
                user.Surname,
                user.Patronymics,
                user.Email,
                user.Username
            });
        }
    }
}
