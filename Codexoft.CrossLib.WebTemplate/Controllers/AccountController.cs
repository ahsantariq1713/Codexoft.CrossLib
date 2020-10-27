using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Codexoft.CrossLib.Architecture.Data.DTOs;
using Codexoft.CrossLib.Architecture.Data.Models;
using Codexoft.CrossLib.Architecture.Helper;
using Codexoft.CrossLib.Architecture.Services.Containers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Codexoft.CrossLib.WebTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly WebServiceContainer _serviceContainer;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountController(WebServiceContainer serviceContainer, IMapper mapper, IConfiguration configuration)
        {
            _serviceContainer = serviceContainer;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await _serviceContainer.UserService.CreateAsync(model, UserRoles.Administrator);
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _serviceContainer.UserService.GetAuthenticatedUserAsync(model);

            if (user == null)
            {
                return Unauthorized();
            }

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.PrimarySid, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var secretBytes = Convert.FromBase64String(_configuration["Jwt:Key"]);
            var securityKey = new SymmetricSecurityKey(secretBytes);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:Expires"])),
                SigningCredentials = signingCredentials
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtTokenHandler.CreateToken(securityTokenDescriptor);

            return Ok(jwtTokenHandler.WriteToken(securityToken));
        }

    }
}
