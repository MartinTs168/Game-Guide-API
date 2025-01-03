using GameGuide.Core.Contracts;
using GameGuide.Core.Models;
using GameGuide.Data.Common;
using GameGuide.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        return await _repository.AllReadOnly<Game>()
            .Select(g => new GameDto
            {
                Id = g.Id,
                Title = g.Title
            }).ToListAsync();
    }

    public async Task<GameDto?> GetGameByIdAsync(int id)
    {
        var game = await _repository.GetByIdAsync<Game>(id);

        if (game == null)
        {
            return null;
        }

        return new GameDto
        {
            Id = game.Id,
            Title = game.Title
        };
    }


    public async Task CreateGameAsync(Game game)
    {
        try
        {
            await _repository.AddAsync(game);
            await _repository.SaveChangesAsync<Game>();
        }
        catch (ArgumentNullException anex)
        {
        }
        
    }

    public async Task<GameDto?> EditGameAsync(int id, CreateGameDto game)
    {
        var currGame = await _repository.GetByIdAsync<Game>(id);

        if (currGame != null)
        {
            
            currGame.Title = game.Title;
            await _repository.SaveChangesAsync<Game>();
            
            return new GameDto
            {
                Id = currGame.Id,
                Title = currGame.Title
            };

        }
        
        return null;
    }

    public async Task<int> DeleteGameAsync(int id)
    {
        var game = await _repository.GetByIdAsync<Game>(id);

        if (game == null) return -1;

        await _repository.DeleteAsync(game);
        await _repository.SaveChangesAsync<Game>();

        return 0;
    }
}