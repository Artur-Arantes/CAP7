using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Models;
using Fiap.Desafio.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace Fiap.Desafio.Api.Controllers;

    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {   
        
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {   
            if (ModelState.IsValid && _userService.IsLoginAuthorized(loginDto) )
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, loginDto.Login)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }

            return NotFound();
        }
    }