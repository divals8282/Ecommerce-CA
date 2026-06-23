using App.Application.Services;
using App.Infrastructure.Presistence;
using App.Infrastructure.Repositories;
using App.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>((options) => {
    options.UseSqlServer();
});

builder.Services.AddControllers();

builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<CardRepository>();
builder.Services.AddScoped<CheckoutRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();