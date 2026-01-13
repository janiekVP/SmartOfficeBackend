namespace Floorplan.Dtos;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

public class FloorplanCreateDto
{
    [Required, MaxLength(100)]
    public string Country { get; set; }

    [Required, MaxLength(100)]
    public string District { get; set; }

    [Required, MaxLength(100)]
    public string City { get; set; }

    [Required, MaxLength(150)]
    public string Company { get; set; }

    [Required, MaxLength(150)]
    public string Office { get; set; }

    [Required, MaxLength(50)]
    public string Floor { get; set; }
    
    public IFormFile? Image { get; set; }
}

public class FloorplanReadDto
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Company { get; set; }
    public string Office { get; set; }
    public string Floor { get; set; }
    public string? ImageBase64 { get; set; }
    public string? ImageContentType { get; set; }

}

