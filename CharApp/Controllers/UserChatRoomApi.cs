using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CharApp.Repository;
using CharApp.Models;
using CharApp.Repository.IRepository;

namespace CharApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChatRoomApi : ControllerBase
    {
        
        private IUnitOfWork _repository;
        private IMapper _mapper;
        public UserChatRoomApi(IUnitOfWork repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        
        // GET: api/<ChatRoomController>
        [HttpGet]
        public IActionResult  GetAllUserChatRooms()
        {
            var userChatRooms = _repository.UserChatRoomRepository.GetallAsync().Result;
            var userChatRoomDtoGets = _mapper.Map<IEnumerable<UserChatRoomDTOGet>>(userChatRooms);
            return Ok(userChatRoomDtoGets);
        }

        // GET api/<ChatRoomController>/5
        [HttpGet("{id}")]
        public IActionResult  GetUserChatRoom(string id)
        {
            var userChatRoom = _repository.UserChatRoomRepository.GetAsync(p=>p.RoomId.Equals(id)).Result.FirstOrDefault();
            var userChatRoomDtoGet = _mapper.Map<UserChatRoomDTOGet>(userChatRoom);
            if (userChatRoomDtoGet is null)
            {
                return NotFound();
            }

            return Ok(userChatRoomDtoGet);
        }

        // POST api/<ChatRoomController>
        [HttpPost]
        public async Task<IActionResult>  CreateUserChatRoom([FromBody] UserChatRoomDTOCreate value)
        {

            if (value is null)
            {
                return BadRequest();
            }

            await _repository.UserChatRoomRepository.AddAsync(_mapper.Map<UserChatRoom>(value));
            return Created();
        }

        // PUT api/<ChatRoomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserChatRoom(string id, [FromBody] UserChatRoomDTOCreate value)
        {
            if (value is  null)
            {
                return BadRequest();
            }

            
            var chatroom = _repository.UserChatRoomRepository.GetAsync(p=>p.RoomId.Equals(id)).Result.FirstOrDefault();
            if (chatroom is null)
            {
                return NotFound();
            }

            await _repository.UserChatRoomRepository.UpdateAsync(id,_mapper.Map<UserChatRoom>(value));
            return Ok();

        }

        // DELETE api/<ChatRoomController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserChatRoom(string id)
        {

           
            var chatroom = _repository.UserChatRoomRepository.GetAsync(p=>p.RoomId.Equals(id)).Result.FirstOrDefault();
            if (chatroom is null)
            {
                return NotFound();
            }

            await  _repository.UserChatRoomRepository.DeleteAsync(chatroom);
            return Ok();
        }
    }
}
