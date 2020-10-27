using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Codexoft.CrossLib.Architecture.Services.Containers;
using Codexoft.CrossLib.Architecture.Data.DTOs;

namespace Codexoft.CrossLib.WebTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WebServiceContainer
            _serviceContainer;
        private readonly IMapper _mapper;

        public UserController(WebServiceContainer serviceContainer, IMapper mapper)
        {
            _serviceContainer = serviceContainer;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _serviceContainer.UserService.GetAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _serviceContainer.UserService.GetAsync(id);
            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}
