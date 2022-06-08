using MuhammetAliDemir.TP.Net.Hw4.Application.DependencyContainer;
using MuhammetAliDemir.TP.Net.Hw4.Infrastructure.DependencyContainer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding containers for layers.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfractructureServices(builder.Configuration);


builder.Services.AddControllers();
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
