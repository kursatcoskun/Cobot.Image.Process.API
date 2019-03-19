using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HumanParts.Detection.API.Data;
using HumanParts.Detection.API.Dto;
using HumanParts.Detection.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HumanParts.Detection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepo _authRepository;
        private IConfiguration _configuration;

        public AuthController(IAuthRepo authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegister userForRegister)
        {
            if (await _authRepository.UserExist(userForRegister.UserName))
            {
                ModelState.AddModelError("UserName", "Username Already Exists");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userToCreate = new User
            {
                UserName = userForRegister.UserName
            };

            var createdUser = await _authRepository.Register(userToCreate, userForRegister.Password);
            return StatusCode(201);


        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserForLogin userForLogin)
        {
            var user = await _authRepository.Login(userForLogin.UserName, userForLogin.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                , SecurityAlgorithms.HmacSha512Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            //return Ok(tokenString);
            return Ok("{\"tokenString\":\"" + tokenString + "\"}");


        }
    }
}