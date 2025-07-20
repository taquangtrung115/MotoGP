using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MotoGP.API.Extensions;
using MotoGP.Application.Auth;
using MotoGP.Application.Interfaces;
using MotoGP.Application.Interfaces.Services;
using MotoGP.Infrastructure;
using MotoGP.Infrastructure.Auth;
using MotoGP.Infrastructure.Services;

using MotoGP.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Tách các phần cấu hình
builder.ConfigureBuilder();

builder.Services.RegisterServices();

var app = builder.Build();

app.UseApplication();

app.MapControllers(); // Đảm bảo đã AddControllers trong DI nếu có

app.Run();
