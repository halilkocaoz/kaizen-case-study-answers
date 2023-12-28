using System.Collections.Generic;
using System.Linq;
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
            var id = Helpers.GenerateCode();
            codes.Add(id);
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
            var id = Helpers.GenerateCode();
            codes.Add(id);
        }
        var uniqueCodes = codes.Distinct().ToList();
        Assert.AreEqual(mustCount, uniqueCodes.Count);
    }
    
    [TestMethod]
    public void UniqueTest_100000()
    {
        const int mustCount = 100000;
        var codes = new List<string>();
        for (var i = 0; i < mustCount; i++)
        {
            var id = Helpers.GenerateCode();
            codes.Add(id);
        }
        var uniqueCodes = codes.Distinct().ToList();
        Assert.AreEqual(mustCount, uniqueCodes.Count);
    }
}

