#

## CodeGenerator

[Code generator](/CodeGenerator/Helpers.cs) implemented with cryptographic random number generator(<https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.randomnumbergenerator?view=net-8.0>). There is also [tests](/CodeGenerator/Helpers.Test.cs)

- UniqueTest_1000
- UniqueTest_10000
- RegexTest
- LenTest

## ReceiptParse

[ReceiptParse](/ReceiptParse/ReceiptParser.cs) seperates receipt lines using two flows. First, groups receipt items based on their average Y coordinates and gets a sorted list of these items. Seconds, segments items that obtained from first flow into lines based on a specified threshold value for the vertical distance between items, returns these lines as groups of items.

I couldn't write test cases because I didn't have the more data.

You can reach the [first parsing attempt result](/ReceiptParse/first-parsing-attempt.txt), and [final result](/ReceiptParse/parsed.txt).

## Thanks for taking time to review
