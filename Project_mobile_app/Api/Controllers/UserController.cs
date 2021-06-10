using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_mobile_app.Models;
using Project_mobile_app.Interfaces.Services;
using Project_mobile_app.Api.Validators;
using AutoMapper;
using Project_mobile_app.Api.Resources.UserResources;

namespace Project_mobile_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this._mapper = mapper;
            this._userService = userService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAllUsers()
        {
            var users = await _userService.GetAll();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(userResources);
        }

        [HttpGet("WithStatAndGames")]
        public async Task<ActionResult<IEnumerable<UserWithStatAndGamesResource>>> GetAllUsersWithStatAndGames()
        {
            var users = await _userService.GetAllWithStatsAndGames();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserWithStatAndGamesResource>>(users);
            return Ok(userResources);
        }

        [HttpGet("WithStatAndGames{id}")]
        public async Task<ActionResult<UserWithStatAndGamesResource>> GetAllUsersWithStatAndGamesById(int id)
        {
            var user = await _userService.GetWithStatsAndGamesById(id);
            var userResource = _mapper.Map<User, UserWithStatAndGamesResource>(user);
            return Ok(userResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetUserById(int id)
        {
            var user = await _userService.GetById(id);
            var userResource = _mapper.Map<User, UserResource>(user);
            return Ok(userResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<UserResource>> CreateUser([FromBody] UserSaveResource user)
        {
            var validator = new UserSaveResourceValidator();
            var validationResult = await validator.ValidateAsync(user);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToCreate = _mapper.Map<UserSaveResource, User>(user);

            userToCreate.Statistics = new Statistics() { NumberOfGamesPlayed = 0, SuccesfullGames = 0, TimeInGames = 0 };

            var newUser = await _userService.CreateUser(userToCreate);

            var createdUser = await _userService.GetById(newUser.Id);

            var userResource = _mapper.Map<User, UserResource>(createdUser);

            return Ok(userResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResource>> UpdateUser(int id, [FromBody] UserSaveResource user)
        {
            var validator = new UserSaveResourceValidator();
            var validationResult = await validator.ValidateAsync(user);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToBeUpdate = await _userService.GetById(id);

            if (userToBeUpdate == null)
                return NotFound();

            var mappedUser = _mapper.Map<UserSaveResource, User>(user);

            await _userService.UpdateUser(userToBeUpdate, mappedUser);

            var updatedUser = await _userService.GetById(id);
            var updatedUserResource = _mapper.Map<User, UserResource>(updatedUser);

            return Ok(updatedUserResource);
        }

        [HttpPut("WithStat{id}")]
        public async Task<ActionResult<UserResource>> UpdateUserWithStat(int id, [FromBody] UserSaveWithStatResource user)
        {
            var validator = new UserSaveWithStatResourceValidator();
            var validationResult = await validator.ValidateAsync(user);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToBeUpdate = await _userService.GetWithStatsById(id);

            if (userToBeUpdate == null)
                return NotFound();

            var mappedUser = _mapper.Map<UserSaveWithStatResource, User>(user);

            await _userService.UpdateUserWithStat(userToBeUpdate, mappedUser);

            var updatedUser = await _userService.GetWithStatsAndGamesById(id);
            var updatedUserResource = _mapper.Map<User, UserWithStatAndGamesResource>(updatedUser);

            return Ok(updatedUserResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetById(id);

            await _userService.DeleteUser(user);

            return NoContent();
        }
    }
}
