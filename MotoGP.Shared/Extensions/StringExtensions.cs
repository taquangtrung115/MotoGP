using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Shared.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string? input)
        => string.IsNullOrEmpty(input);

    public static bool IsNullOrWhiteSpace(this string? input)
        => string.IsNullOrWhiteSpace(input);

    public static string ToSlug(this string input)
    {
        return input
            .ToLowerInvariant()
            .Replace(" ", "-")
            .Replace("đ", "d")
            .Normalize()
            .Trim();
    }
}
