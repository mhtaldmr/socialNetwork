using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Application.Dtos;
using TP.Net.Hw4.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace TP.Net.Hw4.WebApi.WebAPI.Controllers
{
    [Authorize]
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


        [HttpGet("authorization")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetUserAll();
            if(users is null)
                return NotFound();

            var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

            return Ok(userDto);            
        }


        [HttpGet("inmemorycache")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUsersByInMemory()
        {
            var users = await _userRepository.GetUserAll();
            if (users is null)
                return NotFound();

            var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

            return Ok(userDto);
        }


        [HttpGet("distributedcache")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUsersByDistributed()
        {
            var users = await _userRepository.GetUserAll();
            if (users is null)
                return NotFound();

            var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

            return Ok(userDto);
        }




        //[HttpPost]
        //public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        //{
        //    if(!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var user = _mapper.Map<UserDto, User>(userDto);
        //    _userRepository.Add(user);

        //    await _unitOfWork.CompleteAsync();
        //    return Created("/users",user);
        //}
    }
}
