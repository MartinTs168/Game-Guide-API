using System.ComponentModel.DataAnnotations;
using static GameGuide.Data.Constants.EntitiesConstants;

namespace GameGuide.Data.Entities;

public class Game
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GameTitleMaxLength)]
    public string Title { get; set; } = null!;
    
    public IEnumerable<Article>? Artilces = new List<Article>();
}