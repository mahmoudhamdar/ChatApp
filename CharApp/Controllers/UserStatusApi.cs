using AutoMapper;
using CharApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CharApp.Repository;
using CharApp.Repository.IRepository;

namespace CharApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatusApi : ControllerBase
    {
        private IUnitOfWork _repository;
        private IMapper _mapper;
        public UserStatusApi(IUnitOfWork repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        // GET: api/<ChatRoomController>
        [HttpGet]
        public IActionResult  GetAllUserStatuses()
        {
            var userStatuses = _repository.UserStatusRepository.GetallAsync().Result;
            var userStatusesDto = _mapper.Map<IEnumerable<UserStatusDTOGet>>(userStatuses);
            return Ok(userStatusesDto);
        }

        // GET api/<ChatRoomController>/5
        [HttpGet("{id}")]
        public IActionResult  GetUserStatus(string id)
        {
           
            var userStatus = _repository.UserStatusRepository.GetAsync(p=>p.UserId==id).Result.FirstOrDefault();
            var userStatusDto = _mapper.Map<UserStatusDTOGet>(userStatus);
            if (userStatus is null)
            {
                return NotFound();
            }

            return Ok(userStatusDto);
        }

        // POST api/<ChatRoomController>
        [HttpPost]
        public async Task<IActionResult>  CreateUserStatus([FromBody] UserStatusDTOCreate value)
        {
           

            if (value==null)
            {
                return BadRequest();
            }

            await _repository.UserStatusRepository.AddAsync(_mapper.Map<UserStatus>(value));
            return Created();
        }

        // PUT api/<ChatRoomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserStatus(string id, [FromBody] UserStatusDTOCreate value)
        {
            

            if (value is null)
            {
                return BadRequest();
            }

          
            var userStatus = _repository.UserStatusRepository.GetAsync(p=>p.UserId==id).Result.FirstOrDefault();
            var userStatusDto = _mapper.Map<UserStatus>(userStatus);
            if (userStatus is null)
            {
                return NotFound();
            }

            await _repository.UserStatusRepository.UpdateAsync(id,userStatusDto);
            return Ok();

        }

        // DELETE api/<ChatRoomController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStatus(string id)
        {

           
            var userStatus = _repository.UserStatusRepository.GetAsync(p=>p.UserId==id).Result.FirstOrDefault();
            if (userStatus is null)
            {
                return NotFound();
            }

            await  _repository.UserStatusRepository.DeleteAsync(userStatus);
            return Ok();
        }
    }
}
