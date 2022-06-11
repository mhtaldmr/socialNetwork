using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Application.Dtos;
using TP.Net.Hw4.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using System.Text.Json;
using TP.Net.Hw4.Infrastructure.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace TP.Net.Hw4.WebApi.WebAPI.Controllers
{
    [Authorize]
    [Route("/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string _cacheKeyInMemory = "UserListInMemory";
        private const string _cacheKeyDistributed = "UserListDistributed";

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public UsersController(IUserRepository userRepository,IUnitOfWork unitOfWork,IMapper mapper,IMemoryCache memoryCache,IDistributedCache distributedCache)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
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
            if (_memoryCache.TryGetValue(_cacheKeyInMemory, out IEnumerable<UserDto> userCache))
            {
                return Ok(userCache);
            }
            else
            {
                var users = await _userRepository.GetUserAll();
                if (users is null)
                    return NotFound();

                var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

                //Start the caching!
                var cacheOptions = InMemoryCacheEntryOptions.InMemoryCacheEntryOptionParams();
                _memoryCache.Set(_cacheKeyInMemory, userDto, cacheOptions);
                
                return Ok(userDto);
            }
        }


        [HttpGet("distributedcache")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUsersByDistributed()
        {

            var userCache= _distributedCache.Get(_cacheKeyDistributed);
            if (userCache != null)
            {
                var serializedUserList = Encoding.UTF8.GetString(userCache);
                var userDtoResult = JsonSerializer.Deserialize<IEnumerable<UserDto>>(serializedUserList);
                return Ok(userDtoResult);
            }
            else
            {
                var users = await _userRepository.GetUserAll();
                if (users is null)
                    return NotFound();

                var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

                var jsonArr = JsonSerializer.Serialize(userDto);
                var cacheOptions = DistributedCachingEntryOptions.DistributedCachingEntryOptionsParams();
                _distributedCache.Set(_cacheKeyDistributed, Encoding.UTF8.GetBytes(jsonArr), cacheOptions);

                return Ok(userDto);
            }
            
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
