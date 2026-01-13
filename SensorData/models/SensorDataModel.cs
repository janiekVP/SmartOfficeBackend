using System.ComponentModel.DataAnnotations;

namespace SensorData.models;

public class SensorDataModel
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