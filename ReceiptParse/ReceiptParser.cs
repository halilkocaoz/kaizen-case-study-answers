using ReceiptParse.Models;

namespace ReceiptParse;

public static class ReceiptParser
{
    /// <summary>
    /// Parses the receipt items into lines of text.
    /// </summary>
    public static List<string> GetLines(List<ReceiptItem> receiptItems, int lineThreshold)
    {
        receiptItems!.RemoveAt(0);
        receiptItems = GetAsOrderedByAverageYCoordinate(receiptItems);

        var lines = GetLines(lineThreshold, receiptItems);
        var linesAsStrings = lines.Select(line => string.Join(" ", line.Select(item => item.Description))).ToList();

        return linesAsStrings;
    }

    /// <summary>
    /// Groups receipt items based on their average Y coordinates and returns a sorted list of these items.
    /// </summary>
    private static List<ReceiptItem> GetAsOrderedByAverageYCoordinate(IEnumerable<ReceiptItem> receiptItems)
    {
        var groupedInvoiceObjects = receiptItems.GroupBy(x =>
        {
            var averageY = x.BoundingPoly.Vertices.Sum(v => v.Y) / x.BoundingPoly.Vertices.Count;
            var roundedY = Math.Round(averageY / 10.0) * 10;
            return roundedY;
        }).OrderBy(x => x.Key);

        return groupedInvoiceObjects.SelectMany(x => x).ToList();
    }

    /// <summary>
    /// Segments a list of receipt items into lines based on a specified threshold for the vertical distance between items, returns these lines as groups of items.
    /// </summary>
    private static IEnumerable<IReadOnlyList<ReceiptItem>> GetLines(int lineThreshold,
        IReadOnlyList<ReceiptItem> receiptItems)
    {
        var lines = new List<List<ReceiptItem>>();
        var currentLine = new List<ReceiptItem> {receiptItems[0]};

        for (var i = 1; i < receiptItems.Count; i++)
        {
            var difference = receiptItems[i].BoundingPoly.Vertices[0].Y - currentLine[^1].BoundingPoly.Vertices[0].Y;

            if (difference > lineThreshold)
            {
                // start a new line
                lines.Add(currentLine);
                currentLine = [receiptItems[i]];
            }
            else
            {
                // add to current line
                currentLine.Add(receiptItems[i]);
            }
        }

        lines.Add(currentLine);
        return lines;
    }
}