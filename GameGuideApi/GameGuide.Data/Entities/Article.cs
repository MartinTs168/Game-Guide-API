using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static GameGuide.Data.Constants.EntitiesConstants;

namespace GameGuide.Data.Entities;

public class Article
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(ArticleTitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [Comment("This will contain HTML markup for the content of the article")]
    public string Content { get; set; } = null!;
    
    public int GameKey { get; set; }
    
    [Required]
    [ForeignKey(nameof(GameKey))]
    public Game Game { get; set; } = null!;
}