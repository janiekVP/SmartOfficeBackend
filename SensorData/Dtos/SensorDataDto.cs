namespace SensorData.Dtos;

using System.ComponentModel.DataAnnotations;

public class SensorDataCreateDto
{
    [Required]
    public int POISensorId { get; set; }
    
    [Required]
    public bool Status { get; set; }
    
    [Required, Range(0, 100)]
    public byte Battery { get; set; }
    
    [Required, Range(-50, 100)]
    public float Temperature { get; set; }
    
    [Required, Range(0, 200)]
    public int Noise { get; set; }
    
    [Required, Range(0, 100000)]
    public int Light { get; set; }
    
    [Required, Range(0, 10000)]
    public int Co2 { get; set; }
    
    [Required]
    public DateTime LastComDate { get; set; }
}

public class SensorDataReadDto
{
    public int Id { get; set; }
    public int POISensorId { get; set; }
    public bool Status { get; set; }
    public byte Battery { get; set; }
    public float Temperature { get; set; }
    public int Noise { get; set; }
    public int Light { get; set; }
    public int Co2 { get; set; }
    public DateTime LastComDate { get; set; }
}