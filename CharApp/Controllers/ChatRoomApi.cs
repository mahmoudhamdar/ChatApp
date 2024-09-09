using AutoMapper;
using CharApp.Data;
using CharApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CharApp.Repository;
using CharApp.Repository.IRepository;

namespace CharApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomApi : ControllerBase
    {
        private IUnitOfWork _repository;
        private IMapper _mapper;
        public ChatRoomApi(IUnitOfWork repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        
        // GET: api/<ChatRoomController>
        [HttpGet]
        public IActionResult  GetAllChatRooms()
        {
            var chatrooms = _repository.ChatRoomRepository.GetallAsync().Result;
            var chatroomsDto = _mapper.Map<IEnumerable<ChatRoomDTOGet>>(chatrooms);
            return Ok(chatroomsDto);
        }

        // GET api/<ChatRoomController>/5
        [HttpGet("{id}")]
        public IActionResult  GetChatRoom(string id)
        {
     
            var chatroom = _repository.ChatRoomRepository.GetAsync(p=>p.RoomId.Equals(id)).Result.FirstOrDefault();
            var chatroomDto = _mapper.Map<ChatRoomDTOGet>(chatroom);
            if (chatroomDto is null)
            {
                return NotFound();
            }

            return Ok(chatroomDto);
        }

        // POST api/<ChatRoomController>
        [HttpPost]
        public async Task<IActionResult>  CreateChatRoom([FromBody] ChatRoomDTOCreate value)
        {
            if (value is null)
            {
                return BadRequest();
            }

            await _repository.ChatRoomRepository.AddAsync(_mapper.Map<ChatRoom>(value));
            return Created();
        }

        // PUT api/<ChatRoomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChatRoom(string id, [FromBody] ChatRoomDTOCreate value)
        {
            if (value is  null)
            {
                return BadRequest();
            }
            var chatroom = _repository.ChatRoomRepository.GetAsync(p=>p.RoomId.Equals(id)).Result.FirstOrDefault();
            if (chatroom is null)
            {
                return NotFound();
            }

            await _repository.ChatRoomRepository.UpdateAsync(id,_mapper.Map<ChatRoom>(value));
            return Ok();

        }

        // DELETE api/<ChatRoomController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatRoom(string id)
        {

           
            var chatroom = _repository.ChatRoomRepository.GetAsync(p=>p.RoomId.Equals(id)).Result.FirstOrDefault();
            if (chatroom is null)
            {
                return NotFound();
            }

            await  _repository.ChatRoomRepository.DeleteAsync(chatroom);
            return Ok();
        }
    }
}
