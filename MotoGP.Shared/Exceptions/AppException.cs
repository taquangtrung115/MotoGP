using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Shared.Exceptions;
//throw new AppException("Invalid credentials", 401);
public class AppException : Exception
{
    public int StatusCode { get; }

    public AppException(string message, int statusCode = 400) : base(message)
    {
        StatusCode = statusCode;
    }

    public AppException(string message, Exception innerException, int statusCode = 500)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}
