using EFCore8.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MgDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("EfcoreConStr"));
});

var app = builder.Build();

//var db = app.Services.GetRequiredService<MgDbContext>();
//db.Database.EnsureDeleted();
//db.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
