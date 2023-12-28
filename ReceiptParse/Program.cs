using ReceiptParse;
using ReceiptParse.Models;

var json = File.ReadAllText("receipt.json");
var receiptItems = System.Text.Json.JsonSerializer.Deserialize<List<ReceiptItem>>(json);
if (receiptItems?.Count == 0)
    throw new Exception("No receipt items found.");

var lines = ReceiptParser.GetLines(receiptItems, 10);
var txtBuilder = new System.Text.StringBuilder();
foreach (var line in lines)
    txtBuilder.AppendLine(line);

File.WriteAllText("parsed.txt", txtBuilder.ToString());