using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CharApp.Repository;
using CharApp.Models;
using CharApp.Repository.IRepository;
using CharApp.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace CharApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApi : ControllerBase
    {
        private IUnitOfWork _repository;
        private IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        public UserApi(ITokenService tokenService ,IUnitOfWork repository, IMapper mapper,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _tokenService=tokenService;
            _signInManager = signInManager;
        }
        
        
        // GET: api/<ChatRoomController>
        [HttpGet]
        public IActionResult  GetAllUsers()
        {
            var users = _repository.UserRepository.GetallAsync().Result;
            var usersDto = _mapper.Map<IEnumerable<UserDTOGet>>(users);
            return Ok(usersDto);
        }

        // GET api/<ChatRoomController>/5
        [HttpGet("{id}")]
        public IActionResult  GetUser(string id)
        {
          
            var user = _repository.UserRepository.GetAsync(p => p.Id .Equals( id)).Result.FirstOrDefault();
            var userDto = _mapper.Map<UserDTOGet>(user);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(u=>u.UserName.Equals(value.Username.ToLower()));
            if (user is null)
            {
                return Unauthorized("Invalid username!");
            }
            var result=_signInManager.CheckPasswordSignInAsync(user, value.Password, false).Result;

            if (!result.Succeeded)
            {
                return Unauthorized("Username not found and/or password is incorrect");
            }

            return Ok(new UserDTOGet()
            {
                Id = user.Id,
                Username = value.Username,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            });
        }
        
        // POST api/<ChatRoomController>
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [HttpPost("register")]
        public async Task<IActionResult>  CreateUser([FromBody] UserDTOCreate value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var user = _mapper.Map<User>(value);
                
                var createUser = await _userManager.CreateAsync(user, value.Password);
                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new UserDTOGet
                            {
                                Username = user.UserName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user)
                            }
                            );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
            await _repository.UserRepository.AddAsync(_mapper.Map<User>(value));
            return Created();
        }

        // PUT api/<ChatRoomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserDTOCreate value)
        {
            
            if (value is  null)
            {
                return BadRequest();
            }

          
            var user = _repository.UserRepository.GetAsync(p => p.Id .Equals(id) ).Result.FirstOrDefault();
            if (user is null)
            {
                return NotFound();
            }

            await _repository.UserRepository.UpdateAsync(id, _mapper.Map<User>(value));
            return Ok();

        }

        // DELETE api/<ChatRoomController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            var user = _repository.UserRepository.GetAsync(p => p.Id .Equals(id) ).Result.FirstOrDefault();
            if (user is null)
            {
                return NotFound();
            }

            await  _repository.UserRepository.DeleteAsync(user);
            return Ok();
        }
    }
}
