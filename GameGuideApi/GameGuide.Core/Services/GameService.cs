using GameGuide.Core.Contracts;
using GameGuide.Core.Models;
using GameGuide.Data.Common;
using GameGuide.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameGuide.Core.Services;

public class GameService : IGameService
{
    private readonly IRepository _repository;

    public GameService(IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<GameDto>> AllGamesAsync()
    {
        return await _repository.All<Game>()
            .Select(g => new GameDto
            {
                Id = g.Id,
                Title = g.Title
            }).ToListAsync();
    }
}