using AutoMapper;
using CharApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CharApp.Repository;
using CharApp.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CharApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentApi : ControllerBase
    {
        private IUnitOfWork _repository;
        private IMapper _mapper;
        public AttachmentApi(IUnitOfWork repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        
        // GET: api/<AttachmentController>
        [HttpGet]
        public IActionResult GetAllAttachment()
        {
            var attachments = _repository.AttachmentRepository.GetallAsync().Result;
            var attachmentsDto = _mapper.Map<IEnumerable<AttachmentDTOGet>>(attachments);
            return Ok(attachmentsDto);
        }

        // GET api/<AttachmentController>/5
        [HttpGet("{id}")]
        public IActionResult GetAttachment(string id)
        {
            var attachment = _repository.AttachmentRepository.GetAsync(p => p.AttachmentId .Equals(id)).Result.FirstOrDefault();
            var attachmentDto = _mapper.Map<AttachmentDTOGet>(attachment);
            if (attachmentDto is null)
            {
                return NotFound();
            }
            return Ok(attachmentDto);
        }

        // POST api/<AttachmentController>
        [HttpPost]
        public async Task<IActionResult> CreateAttachment([FromBody] AttachmentDTOCreate value)
        {
            
            if (value is null)
            {
                return BadRequest();
            }
            await _repository.AttachmentRepository.AddAsync(_mapper.Map<Attachment>(value));
            return Created();
        }

        // PUT api/<AttachmentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttachment(string id, [FromBody] AttachmentDTOCreate value)
        {
            if (value is null)
            {
                return BadRequest();
            }
            var attachment = _repository.AttachmentRepository.GetAsync(p => p.AttachmentId.Equals(id)).Result.FirstOrDefault();
            if (attachment is null)
            {
                return NotFound();
            }
            await _repository.AttachmentRepository.UpdateAsync(id,_mapper.Map<Attachment>(value));
            return Ok();
        }

        // DELETE api/<AttachmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachment(string id)
        {
            

            var attachment = _repository.AttachmentRepository.GetAsync(p => p.AttachmentId .Equals(id)).Result.FirstOrDefault();
            if (attachment is null)
            {
                return NotFound();
            }

            await  _repository.AttachmentRepository.DeleteAsync(attachment);
            return Ok();



        }
    }
}
