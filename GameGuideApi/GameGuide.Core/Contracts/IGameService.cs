using GameGuide.Core.Models;
using GameGuide.Data.Entities;

namespace GameGuide.Core.Contracts;

public interface IGameService
{
    Task<IEnumerable<GameDto>> AllGamesAsync();
    
    Task<GameDto?> GetGameByIdAsync(int id);

    Task CreateGameAsync(Game game);

    Task<GameDto?> EditGameAsync(int id, CreateGameDto game);

    Task<int> DeleteGameAsync(int id);
}