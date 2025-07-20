using MotoGP.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Shared.Middleware;

public static class Guard
{
    public static void AgainstNull<T>(T value, string name)
    {
        if (value == null)
            throw new AppException($"{name} should not be null.");
    }

    public static void AgainstNullOrWhiteSpace(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new AppException($"{name} should not be empty.");
    }

    public static void AgainstOutOfRange(int value, string name, int min, int max)
    {
        if (value < min || value > max)
            throw new AppException($"{name} should be between {min} and {max}.");
    }

    public static void AgainstDefault<T>(T value, string name)
    {
        if (EqualityComparer<T>.Default.Equals(value, default!))
            throw new AppException($"{name} should not be default value.");
    }
    
    public static void AgainstNullOrEmpty(string? input, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException($"Parameter '{parameterName}' cannot be null or empty.");
    }

    public static void AgainstOutOfRange(int value, int min, int max, string parameterName)
    {
        if (value < min || value > max)
            throw new ArgumentOutOfRangeException(parameterName, $"Value must be between {min} and {max}.");
    }

    public static void AgainstInvalidGuid(Guid id, string parameterName)
    {
        if (id == Guid.Empty)
            throw new ArgumentException($"Parameter '{parameterName}' cannot be empty Guid.");
    }
}
