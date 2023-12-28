using System;
using System.Security.Cryptography;

namespace CodeGenerator;

public static class Helpers
{
    public static string GenerateCode()
    {
        var bytes = new byte[4];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return BitConverter.ToString(bytes).Replace("-", string.Empty);
    }
}
