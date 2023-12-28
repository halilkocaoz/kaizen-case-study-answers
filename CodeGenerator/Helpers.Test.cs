using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeGenerator;

[TestClass]
public class HelpersTest
{
    [TestMethod]
    public void UniqueTest_1000()
    {
        const int mustCount = 1000;
        var codes = new List<string>();
        for (var i = 0; i < mustCount; i++)
        {
            var code = Helpers.GenerateCode();
            codes.Add(code);
        }
        var uniqueCodes = codes.Distinct().ToList();
        Assert.AreEqual(mustCount, uniqueCodes.Count);
    }
    
    [TestMethod]
    public void UniqueTest_10000()
    {
        const int mustCount = 10000;
        var codes = new List<string>();
        for (var i = 0; i < mustCount; i++)
        {
            var code = Helpers.GenerateCode();
            codes.Add(code);
        }
        var uniqueCodes = codes.Distinct().ToList();
        Assert.AreEqual(mustCount, uniqueCodes.Count);
    }
    
    [TestMethod]
    public void RegexTest()
    {
        var regex = new Regex("^[A-Z0-9]+$");
        for (var i = 0; i < 100000; i++)
        {
            var id = Helpers.GenerateCode();
            Assert.IsTrue(regex.IsMatch(id));
        }
    }
    
    [TestMethod]
    public void LenTest()
    {
        for (var i = 0; i < 100000; i++)
        {
            var id = Helpers.GenerateCode();
            Assert.AreEqual(8, id.Length);
        }
    }
}

