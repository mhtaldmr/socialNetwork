using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP.Net.Hw4.Application.Dtos.Requests;
using TP.Net.Hw4.Application.Interfaces.Repositories;
using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.WebApi.Controllers
{
    [Route("messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserMessageRepository _repository;

        public MessagesController(IMapper mapper, IUserMessageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetUserMessages([FromQuery] UserMessageQueryDto filterDto)
        {
            var filter = _mapper.Map<UserMessageQueryDto, UserMessageQuery>(filterDto);
            var messages = await _repository.GetAllUserMessages(filter);
            if (!messages.Any())
                return NotFound("There is no message by given context!");

            return Ok(messages);
        }
    }
}
