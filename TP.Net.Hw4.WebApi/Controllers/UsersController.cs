using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Application.Dtos;
using TP.Net.Hw4.Application.Interfaces.Repositories;

namespace TP.Net.Hw4.WebApi.WebAPI.Controllers
{
    [Route("/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetUserAll();
            if(users is null)
                return NotFound();

            var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
            //var userDto = _mapper.Map<User, UserDto>(users);

            return Ok(userDto);            
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _mapper.Map<UserDto, User>(userDto);
            _userRepository.Add(user);

            await _unitOfWork.CompleteAsync();
            return Created("/users",user);
        }
    }
}
