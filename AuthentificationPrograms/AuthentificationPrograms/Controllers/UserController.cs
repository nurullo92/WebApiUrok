using AuthentificationPrograms.Exceptions;
using AuthentificationPrograms.Logger;
using AuthentificationPrograms.LoggerCons;
using AuthentificationPrograms.Models;
using AuthentificationPrograms.Repository;
using AuthentificationService;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Security.Principal;

namespace AuthentificationPrograms.Controllers
{
    [ExceptionHandler]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapp;
        private IUserRepository _repo;
        private ILoggers _log;


        public UserController(ILoggers log, IMapper mapp, IUserRepository repo)
        {
            _mapp = mapp;
            _log = log;
            _repo = repo;

            _log.EventLog("Сообшение о событии в программе");
            _log.ErrorLog("Сообщение об ошибке в программе");
        }


        [HttpGet("User")]
        public User GetUser()
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Loggin = "ivan",
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "ivan@gmail.com",
                Password = "1111111122",
            };

        }


        [Authorize]
        [HttpGet("viewmodel")]
        public UserViewModel GetUserViewModel()
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Loggin = "Randmoy",
                FirstName = "Иван",
                LastName = "radoya",
                Email = "ivan@gmail.com",
                Password = "1111111122",
            };


            var userViewModel = _mapp.Map<UserViewModel>(user);

            return userViewModel;
        }



        [HttpGet("All")]
        public IActionResult GetUsers()
        {
            var users = _repo.GetAll();
            return Ok(users);
        }


        [HttpGet("Login")]
        public IActionResult GetLogin(string login)
        {
            var users = _repo.GetByLogin(login);
            return Ok(users);
        }



        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }


        [HttpPost("Authentificate")]
        public async Task<IActionResult> Authentificate([FromForm] LoginRequest logs)
        {
            if (String.IsNullOrEmpty(logs.Loggin) || String.IsNullOrEmpty(logs.Password))
            {
                ModelState.AddModelError("", "Заполните все поля");
                return BadRequest(ModelState);
            }


            User user = _repo.GetByLogin(logs.Loggin);


            if (user is null)
            {
                ModelState.AddModelError("Loggin", "Пользователь не найден");
                return BadRequest(ModelState);
            }


            if (user.Password != logs.Password)
            {
                ModelState.AddModelError("password", "Неверный пароль");
                return BadRequest(ModelState);
            }


            var claims = new List<Claim>()
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Loggin),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
        };

            ClaimsIdentity claimsidentity =
                new ClaimsIdentity(claims,
                "AddCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsidentity
                ));


            var userViewModel = _mapp.Map<UserViewModel>(user);


            return Ok(userViewModel);
        }
        



    }
}
