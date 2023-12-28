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
        var invoiceObjects = JsonSerializer.Deserialize<List<ReceiptItem>>(jsonString);
        invoiceObjects!.RemoveAt(0);

        var groupedInvoiceObjects = invoiceObjects.GroupBy(x =>
        {
            var averageY = x.BoundingPoly.Vertices.Sum(v => v.Y) / x.BoundingPoly.Vertices.Count;
            var roundedY = Math.Round(averageY / 10.0) * 10;
            return roundedY;
        }).OrderBy(x => x.Key);

        var lines = groupedInvoiceObjects.Select(x => string.Join(" ", x.Select(y => y.Description))).ToList();
        return lines;
    }
}