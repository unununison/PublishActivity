using Microsoft.EntityFrameworkCore;
using PublishActivity.Data.Models;
using PublishActivity.Services.Services;
using PublishActivity.Services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<BasePpsContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("BasePPSConnection")),
	ServiceLifetime.Scoped);

//builder.Services.AddDbContext<BasePpsContext>();
builder.Services.AddScoped<IDataBaseService, DataBaseService>();
builder.Services.AddScoped<IImpactFactorService, ImpactFactorService>();
builder.Services.AddScoped<IReportService, ReportService>();

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

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
