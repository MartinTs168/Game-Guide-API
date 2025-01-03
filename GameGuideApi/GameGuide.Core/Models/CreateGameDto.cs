using System.ComponentModel.DataAnnotations;
using static GameGuide.Data.Constants.EntitiesConstants;

namespace GameGuide.Core.Models;

public class CreateGameDto
{
    
    public int Id { get; set; }
    
    [Required]
    [StringLength(GameTitleMaxLength, MinimumLength = GameTittleMinLength, ErrorMessage = "Game {0} must be between {2} and {2}")]
    public string Title { get; set; } = null!;
}