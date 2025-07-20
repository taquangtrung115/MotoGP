using Microsoft.EntityFrameworkCore;
using MotoGP.Application.Auth;
using MotoGP.Domain.Entities;
using MotoGP.Persistence;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly MotoGPDbContext _context;
    private readonly ITokenService _tokenService;

    public AuthService(MotoGPDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<AuthResult> RegisterAsync(RegisterRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            throw new Exception("User already exists");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHash
        };

        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new AuthResult(
            _tokenService.GenerateAccessToken(user),
            refreshToken,
            DateTime.UtcNow.AddMinutes(15),
            user.Username,
            user.Role
        );
    }

    public async Task<AuthResult> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email)
                   ?? throw new Exception("Invalid credentials");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _context.SaveChangesAsync();

        return new AuthResult(
            _tokenService.GenerateAccessToken(user),
            refreshToken,
            DateTime.UtcNow.AddMinutes(15),
            user.Username,
            user.Role
        );
    }

    public async Task<AuthResult> RefreshTokenAsync(string token)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == token)
                   ?? throw new Exception("Invalid refresh token");

        if (user.RefreshTokenExpiryTime < DateTime.UtcNow)
            throw new Exception("Refresh token expired");

        var newToken = _tokenService.GenerateAccessToken(user);
        var newRefresh = _tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefresh;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

        await _context.SaveChangesAsync();

        return new AuthResult(newToken, newRefresh, DateTime.UtcNow.AddMinutes(15), user.Username, user.Role);
    }
}

