namespace POISensor.Dtos;

using System.ComponentModel.DataAnnotations;

public class POISensorCreateDto
{
    [Required]
    public int POIId { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; }
    
    [Required, MaxLength(100)]
    public string Type { get; set; }
}

public class POISensorReadDto
{
    public int Id { get; set; }
    public int POIId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}