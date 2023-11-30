using AutoMapper;
using BE_CRUDJugueteria.Models;
using BE_CRUDJugueteria.Models.DTO;
using BE_CRUDJugueteria.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_CRUDJugueteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListUsers = await _userRepository.GetListUsers();
                var ListUsersDto = _mapper.Map<IEnumerable<UserDTO>>(ListUsers);

                return Ok(ListUsersDto);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                user.Created = DateTime.Now;

                await _userRepository.AddUser(user);

                return CreatedAtAction("Get", new { id = user.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("$id")]

        public async Task<IActionResult> Put(int id,  UserDTO userDto)
        {
            try
            {

                if(id != userDto.Id)
                {
                    return BadRequest();
                }

                var userDb = await _userRepository.GetUserById(userDto.Id);

                if(userDb is null)
                {
                    return NotFound();
                }

                if(userDto.Name is not null)
                {
                    userDb.Name = userDto.Name;
                }

                if (userDto.Email is not null)
                {
                    userDb.Email = userDto.Email;
                }

                if (userDto.Role is not null)
                {
                    userDb.Role = userDto.Role;
                }

                await _userRepository.UpdateUser(userDb);

                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
