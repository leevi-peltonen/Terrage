using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TerrageApi.Models;
using TerrageApi.Models.DTO;
using TerrageApi.Services;
using TerrageApi.Utils;

namespace TerrageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUser(int id)
        {
            User User = await _userService.ReadUserAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserReadDTO>(User);

        }


        // POST: api/Users
        [HttpPost("Register")]
        public async Task<ActionResult<UserReadDTO>> RegisterUser([FromBody] UserCreateDTO userDto)
        {
            if (await _userService.UserExists(userDto.Username))
            {
                return BadRequest("Username is already taken.");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            User user = await _userService.CreateUserAsync(_mapper.Map<User>(new UserCreateDTO
            {
                Username = userDto.Username,
                Password = hashedPassword,
                Email = userDto.Email,
            }));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = SecretKeyGenerator.GenerateRandomSecretKey(32);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { Token = tokenHandler.WriteToken(token), User = _mapper.Map<UserReadDTO>(user) });
        }

        // POST: api/Users/Login
        [HttpPost("Login")]
        
        public async Task<ActionResult<UserReadDTO>> LoginUser([FromBody] UserLoginDTO loginDto)
        {
            User user = await _userService.GetUserByUsernameAsync(loginDto.Username);
            if (user == null)
            {
                return NotFound();
            }
            if(!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return Unauthorized("Invalid username or password");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = SecretKeyGenerator.GenerateRandomSecretKey(32);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { Token = tokenHandler.WriteToken(token), User = _mapper.Map<UserReadDTO>(user) });
        }
    }
}
