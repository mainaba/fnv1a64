using System.Text;

namespace CSharp;

/// <summary>
/// Computes the FNV1A64 hash for the input string.
/// </summary>
internal sealed class FNV1A64
{
    private const ulong _basis = 0xCBF29CE484222325;
    private const ulong _prime = 0x00000100000001B3;

    /// <summary>
    /// Generates a hash value.
    /// </summary>
    /// <param name="s">the input string</param>
    /// <returns>the message digest</returns>
    internal static string Hash(string s)
    {
        ulong hash = _basis;
        Encoding.ASCII.GetBytes(s).ToList().ForEach(b =>
        {
            hash ^= b;
            hash *= _prime;
        });
        byte[] bytes = BitConverter.GetBytes(hash).Reverse().ToArray();
        return Convert.ToHexString(bytes);
    }
}
