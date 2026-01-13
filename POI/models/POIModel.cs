namespace POI.models;

public class POIModel
{
    public int Id { get; set; }
    public int FloorplanId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public double CoordX { get; set; }
    public double CoordY { get; set; }
}