using Hangfire;
using TP.Net.Hw.Application.DependencyContainer;
using TP.Net.Hw.Infrastructure.Common.Extensions;
using TP.Net.Hw.Infrastructure.DependencyContainer;


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

//Using for authentication!
app.UseAuthentication();
//Hangfire DashBoard
app.UseHangfireDashboard();
//Generating custom extension for Recuirring jobs.
app.UseHangfireJobs();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
