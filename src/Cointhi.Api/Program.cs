using Cointhi.Api.Controllers.Auth;
using Cointhi.Api.Cryptography;
using Cointhi.Api.Database;
using Cointhi.Api.Exceptions;
using Cointhi.Api.UseCases;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Database
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddCryptography();

builder.Services.AddAuthentication(options =>  
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("Jwt");

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!)),
        ValidAudience = jwtSettings["Audience"],
        ValidIssuer = jwtSettings["Issuer"],
    };
});

builder.Services.AddAuthorization();

builder.Services.AddUseCases();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/api-docs");
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapAuthRoutesApi();
app.MapTransactionRoutesApi();

app.Run();