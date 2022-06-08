using Microsoft.EntityFrameworkCore;
using MuhammetAliDemir.TP.Net.Hw4.Application.Interfaces;
using MuhammetAliDemir.TP.Net.Hw4.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Adding the dbcontext for entityframework
var configuration = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<SocialNetworkDbContext>(options => options.UseSqlServer(configuration));

builder.Services.AddScoped<ISocialNetworkDbContext, SocialNetworkDbContext>();


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