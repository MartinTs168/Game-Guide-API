using GameGuide.Core.Contracts;
using GameGuide.Core.Models;
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
    
    [HttpGet("all")]
    public async Task<IActionResult> All()
    {
        var games = await _gameService.AllGamesAsync();
        
        return Ok(games);
    }
}