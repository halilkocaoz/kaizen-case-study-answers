var json = File.ReadAllText("receipt.json");
var lines = ReceiptParser.GetLines(json);
var txtBuilder = new System.Text.StringBuilder();
foreach (var line in lines)
    txtBuilder.AppendLine(line);

File.WriteAllText("parsed.txt", txtBuilder.ToString());