using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MotoGP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Application.Auth;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}

