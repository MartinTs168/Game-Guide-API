using GameGuide.Core.Models;

namespace GameGuide.Core.Contracts;

public interface IGameService
{
    Task<IEnumerable<GameDto>> AllGamesAsync();
}