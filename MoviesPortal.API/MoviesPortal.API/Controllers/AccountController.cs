using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesPortal.API.DataModels;
using MoviesPortal.API.DomainModels;
using MoviesPortal.API.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MoviesPortal.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MoviesContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAccountService _accountService;

        public AccountController(MoviesContext context, IPasswordHasher<User> passwordHasher, IAccountService accountService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == dto.Email);

                if (existingUser == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Podano nieprawidłowy adres email"
                            },
                        Success = false
                    });
                }
                var result = _passwordHasher.VerifyHashedPassword(existingUser, existingUser.PasswordHash, dto.Password);
                if (result == PasswordVerificationResult.Failed)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Podano nieprawidłowe hasło"
                            },
                        Success = false
                    });
                }
                var token = _accountService.GenerateJwt(dto);

                return Ok(new RegistrationResponse()
                {
                    Success = true,
                    Token = token
                });
            }
            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });

        }
    }
}
