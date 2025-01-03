using GameGuide.Core.Contracts;
using GameGuide.Core.Models;
using GameGuide.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GameGuideApi.Controllers;

[ApiController]
[Route("game")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    
    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GameDto>>> All()
    {
        var games = await _gameService.AllGamesAsync();
        
        return Ok(games);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GameDto>> GetById(int id)
    {
        var game = await _gameService.GetGameByIdAsync(id);
        
        if (game == null)
        {
            return NotFound();
        }

        return Ok(game);
    }

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateGameDto? game)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newGame = new Game
        {
            Title = game!.Title
        };
        
        await _gameService.CreateGameAsync(newGame);

        return CreatedAtAction(nameof(GetById), new { id = newGame.Id }, newGame);



    }
}