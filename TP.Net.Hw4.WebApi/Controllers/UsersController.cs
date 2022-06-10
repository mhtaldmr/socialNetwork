using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Application.Dtos;
using TP.Net.Hw4.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using TP.Net.Hw4.Infrastructure.Caching;

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
        private readonly IMemoryCache _memoryCache;
        private const string userListCacheKey = "UserList";

        public UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork,IMapper mapper,IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
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
            //check the cache if it has data return cache!..
            if (_memoryCache.TryGetValue(userListCacheKey, out IEnumerable<UserDto> userDto))
            {
                return Ok(userDto);
            }
            else
            {
                var users = await _userRepository.GetUserAll();
                if (users is null)
                    return NotFound();

                userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

                var cacheOptions = InMemoryEntryOptions.InMemoryEntryOptionParams();

                _memoryCache.Set(userListCacheKey, userDto, cacheOptions);
            }

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
