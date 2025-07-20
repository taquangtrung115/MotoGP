using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Shared.Responses;
//Cách dùng trong Service:

//csharp
//Sao chép
//Chỉnh sửa
//if (user == null)
//    return Result.Failure("User not found");

//return Result.Success("User registered successfully");
public class Result
{
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;
    public string? Message { get; private set; }
    public List<string> Errors { get; private set; } = new();

    protected Result(bool isSuccess, string? message = null)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result Success(string? message = null)
        => new(true, message);

    public static Result Failure(params string[] errors)
    {
        var result = new Result(false);
        result.Errors.AddRange(errors);
        return result;
    }

    public static Result<T> Success<T>(T value, string? message = null)
        => new(value, true, message);

    public static Result<T> Failure<T>(params string[] errors)
        => new(default!, false, null) { Errors = errors.ToList() };
}
public class Result<T> : Result
{
    public T Value { get; private set; }

    internal Result(T value, bool isSuccess, string? message = null)
        : base(isSuccess, message)
    {
        Value = value;
    }
}
