using System.Text.Json;
using System.Text.Json.Serialization;

public class BoundingPoly
{
    [JsonPropertyName("vertices")]
    public List<Vertex> Vertices { get; set; }
}

public class ReceiptItem
{
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("boundingPoly")]
    public BoundingPoly BoundingPoly { get; set; }
}

public class Vertex
{
    [JsonPropertyName("x")]
    public int X { get; set; }
    [JsonPropertyName("y")]
    public int Y { get; set; }
}

public static class ReceiptParser
{
    public static List<string> GetLines(string jsonString)
    {
        return new List<string>();
    }
}
