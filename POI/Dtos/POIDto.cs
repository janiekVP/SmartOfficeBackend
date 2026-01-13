namespace POI.Dtos;

using System.ComponentModel.DataAnnotations;

public class POICreateDto
{
    [Required]
    public int FloorplanId { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; }
    
    [Required, MaxLength(100)]
    public string Type { get; set; }
    
    [Required, MaxLength(250)]
    public string Description { get; set; }
    
    [Required]
    public double CoordX { get; set; }
    
    [Required]
    public double CoordY { get; set; }
}

public class POIReadDto
{
    public int Id { get; set; }
    public int FloorplanId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public double CoordX { get; set; }
    public double CoordY { get; set; }
}