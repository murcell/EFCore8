using EFCore8.ConsoleApp.Data;
using EFCore8.ConsoleApp.Entities;
using EFCore8.ConsoleApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

Console.WriteLine("Uygulama başladı!");

//IConfiguration configuration = new ConfigurationBuilder()
//	.SetBasePath(Environment.CurrentDirectory)
//	.AddJsonFile("appsettins.json", optional: true, reloadOnChange: true)
//	.Build();

//  var ops = new DbContextOptionsBuilder<MgDbContext>()
//  .UseSqlServer(configuration.GetConnectionString("EfcoreConStr"))
//	.LogTo(Console.WriteLine, LogLevel.Information)
//	.Options;

//// MgDbContext db = new (ops);
//// db.Database.EnsureDeleted();
//// db.Database.EnsureCreated();

var services = new ServiceCollection();
//services.AddDbContext<MgDbContext>(options => {
//	new MgDbContext(ops);
//});

services.AddDbContext<MgDbContext>(options =>
{
	IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
	options.UseSqlServer(configuration.GetConnectionString("EfcoreConStr"));
	options.LogTo(Console.WriteLine, LogLevel.Information);
});

services.AddSingleton<IConfiguration>(cfg =>
{
	return new ConfigurationBuilder()
	.SetBasePath(Environment.CurrentDirectory)
	.AddJsonFile("appsettins.json", optional: true, reloadOnChange: true)
	.Build();
});
services.AddScoped<UserMgCommands>();
services.AddScoped<UserMgQueries>();

ServiceProvider provider = services.BuildServiceProvider();

MgDbContext db = provider.GetRequiredService<MgDbContext>();
db.Database.EnsureDeleted();
db.Database.Migrate();

UserMgCommands userCommand = provider.GetRequiredService<UserMgCommands>();
userCommand.AddUser(new UserMg { Name = "User eleven", Age = 11 });

UserMgQueries userMgQueries = provider.GetRequiredService<UserMgQueries>();
var usersAll = userMgQueries.GetAllUsers();

usersAll.ForEach(user => {
    Console.WriteLine(user.Id + "\t" + user.Name +"\t"+ user.Age);
});
















Console.ReadLine();



