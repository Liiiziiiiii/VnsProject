using Microsoft.EntityFrameworkCore;
using Serilog;
using Vns.Context;
using Vns.Service.Student;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentContext>
    (options => options.UseNpgsql
    (builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

Log.Logger = new LoggerConfiguration().WriteTo.File("./Logs.applog-.txt").CreateLogger();

builder.Services.AddTransient<IStudentService, StudentService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
