using AutoMapper;
using CharApp.Models;
using CharApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CharApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageApi : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork Repository;

    private MessageApi(IUnitOfWork repository, IMapper mapper)
    {
        Repository = repository;
        _mapper = mapper;
    }

    // GET: api/<MessageController>
    [HttpGet]
    public IActionResult GetAllMessages()
    {
        var messages = Repository.MessageRepository.GetallAsync().Result;
        var messagesDto = _mapper.Map<IEnumerable<MessageDTOGet>>(messages);
        return Ok(messagesDto);
    }

    // GET api/<MessageController>/5
    [HttpGet("{id}")]
    public IActionResult GetMessage(string id)
    {
        var message = Repository.MessageRepository.GetAsync(p => p.MessageId.Equals(id)).Result.FirstOrDefault();
        var messageDto = _mapper.Map<MessageDTOGet>(message);
        if (message is null) return NotFound();
        return Ok(messageDto);
    }

    // POST api/<MessageController>
    [HttpPost]
    public async Task<IActionResult> CreateMessage([FromBody] MessageDTOCreate value)
    {
        if (value is null) return NotFound();
        await Repository.MessageRepository.AddAsync(_mapper.Map<Message>(value));

        return Created();
    }

    // PUT api/<MessageController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMessage(string id, [FromBody] MessageDTOCreate? value)
    {
        var mess = Repository.MessageRepository.GetAsync(p => p.MessageId.Equals(id)).Result.FirstOrDefault();
        var messDto = _mapper.Map<MessageDTOCreate>(mess);
        if (messDto is null) return NotFound();

        if (value is null) return BadRequest();


        await Repository.MessageRepository.UpdateAsync(id, _mapper.Map<Message>(value));

        return Ok();
    }

    // DELETE api/<MessageController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(string id)
    {
        var mess = Repository.MessageRepository.GetAsync(p => p.MessageId.Equals(id)).Result.FirstOrDefault();
        if (mess is null) return NotFound();

        await Repository.MessageRepository.DeleteAsync(mess);
        return Ok();
    }
}