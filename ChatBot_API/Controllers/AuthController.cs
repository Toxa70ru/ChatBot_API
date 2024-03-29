using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot_API.Controllers
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

        /*[HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _authService.Users;
        }

        // GET api/<StatusesController>/5
        [HttpGet("{id}")]
        public Status GetStatus(long id)
        {
            Status SN = _authService.Users.Find(id);
            return SN;
        }*/

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationRequest request)
        {
            var user = _authService.Authenticate(request.Username, request.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Неверное имя пользователя или пароль" });
            }
            return Ok(new
            {
                user.Id,
                user.Name,
                user.Surname,
                user.Patronymic,
                user.Email,
                user.Username,
                //user.Password
            });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegistrationRequest request)
        {
            var newUser = new User
            {
                //Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronumics,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password
            };
            var user = _authService.Register(newUser, request.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Имя пользователя уже занято" });
            }

            return Ok(new
            {
                //user.Id,
                user.Name,
                user.Surname,
                user.Patronymic,
                user.Email,
                user.Username
            });
        }
    }
}
