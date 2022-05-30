using English.Core.Entities;
using English.Core.Repositories;
using English.Infrastructure;
using English.Infrastructure.AutoMapper;
using English.Infrastructure.MyContext;
using English.Infrastructure.Repositories;
using English.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton(AutoMapperConfig.Initialize());
builder.Services.AddScoped<ICollectionRepository, InMemoryCollectionRepository>();
builder.Services.AddScoped<ICollectionServices, CollectionServices>();
builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddDbContext<EnglishAppContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("MyEnglishApiCS")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
