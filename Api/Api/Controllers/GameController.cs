using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Project_mobile_app.Interfaces.Services;
using Api.Resources.GameResources.GameWithUser;
using Api.Resources.GameResources.FullGame;
using Project_mobile_app.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        public GameController(IGameService gameService, IMapper mapper)
        {
            this._mapper = mapper;
            this._gameService = gameService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<GameWithUserResource>>> GetAllGamesWithUsers()
        {
            var games = await _gameService.GetAllWithUsers();
            var gameResources = _mapper.Map<IEnumerable<Game>, IEnumerable<GameWithUserResource>>(games);
            return Ok(gameResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameWithUserResource>> GetGameWithUsersById(int id)
        {
            var game = await _gameService.GetWithUsersById(id);
            var gameResource = _mapper.Map<Game, GameWithUserResource>(game);
            return Ok(gameResource);
        }

        [HttpGet("FullGame{id}")]
        public async Task<ActionResult<GameResource>> GetFullGameById(int id)
        {
            var game = await _gameService.GetFullGameById(id);
            var gameResource = _mapper.Map<Game, GameResource>(game);
            return Ok(gameResource);
        }

    }
}
