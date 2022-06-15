using Hangfire;
using TP.Net.Hw.Application.DependencyContainer;
using TP.Net.Hw.Application.Interfaces.Services;
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

app.UseHttpsRedirection();

app.UseAuthorization();

//Hangfire DashBoard
app.UseHangfireDashboard();
RecurringJob.AddOrUpdate<IReportService>("export-daily-excel", s => s.GetUsersExcelReport(), "34 7 * * 1-5");
RecurringJob.AddOrUpdate<IEmailService>("send-daily-mail", s => s.SendEmailReport(), "35 7 * * 1-5");

app.MapControllers();

app.Run();
