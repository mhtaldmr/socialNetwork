using AutoMapper;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using TP.Net.Hw.Application.Dtos.Requests;
using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.WebUI.Helper;
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.WebUI.Controllers
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
            var users = await _userRepository.GetAllUsers();
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
                var users = await _userRepository.GetAllUsers();
                if (users is null)
                    return NotFound();

                var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

                //Start Caching Set
                var cacheOptions = InMemoryCacheOptions.CacheOptions();
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
                var serializedUserDtoToRead = Encoding.UTF8.GetString(userCache);
                var deserializedUserDto = JsonSerializer.Deserialize<IEnumerable<UserDto>>(serializedUserDtoToRead);
                return Ok(deserializedUserDto);
            }
            else
            {
                var users = await _userRepository.GetAllUsers();
                if (users is null)
                    return NotFound();

                var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

                //Start Caching Set
                var seralizedUserDtoToSet = JsonSerializer.Serialize(userDto);
                var cacheOptions = DistributedCacheOptions.CacheOptions();
                _distributedCache.Set(_cacheKeyDistributed, Encoding.UTF8.GetBytes(seralizedUserDtoToSet), cacheOptions);

                return Ok(userDto);
            }
        
        }
    }
}
