using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TP.Net.Hw.Application.Dtos.Requests;
using TP.Net.Hw.Application.Dtos.Responses;
using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.WebUI.Controllers
{
    [Route("messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserMessageRepository _repository;

        public MessagesController(IMapper mapper, IUserMessageRepository repository) => (_mapper,_repository) = (mapper,repository);
        

        [HttpGet]
        public async Task<IActionResult> GetUserMessages([FromQuery] UserMessageQueryDto filterDto)
        {
            var messages = await _repository.GetAllUserMessages(filterDto);
            if (!messages.Any())
                return NotFound("There is no message by given context!");

            //mapping the messages before sending to client for not showing domain details!.
            var result = _mapper.Map<IEnumerable<UserMessage>, IEnumerable<UserMessagesResponse>>(messages);

            //sending a header response with paging informations
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(_repository.GetMetaData(filterDto)));

            return Ok(result);
        }
    }
}
