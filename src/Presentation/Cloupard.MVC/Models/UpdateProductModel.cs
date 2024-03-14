using System.ComponentModel.DataAnnotations;

namespace Cloupard.MVC.Models;

public class UpdateProductModel
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    public string? Description { get; set; }
}