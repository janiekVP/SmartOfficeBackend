namespace Floorplan.models;

public class FloorplanModel
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Company { get; set; }
    public string Office { get; set; }
    public string Floor { get; set; }
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }

}