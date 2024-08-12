using EFCore8.ConsoleApp.Data;
using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


MgDbContext _context = new MgDbContext();
_context.Database.EnsureDeleted();
_context.Database.EnsureCreated();

var writer = new Writer()
{
	Name = "Dostoyewski",
	Age = 48,
	Books = new List<Book>() {
		new Book { Name = "Suç ve Cezea", PublishYear = 1854, BookType=BookType.Mystery },
		new Book { Name = "Yeraltından Notlat", PublishYear = 1865, BookType=BookType.ClassicFiction },
		new Book { Name = "Kumarbaz", PublishYear = 1842, BookType=BookType.Satire },
		new Book { Name = "İnsancıklar", PublishYear = 1853, BookType=BookType.HistoricalFiction }
	}
};

_context.Writers.Add(writer);
_context.SaveChanges();

UserMg user = new UserMg()
{
	Name = "Second User",
	Age = 45,
	Address = new Address { AddressDetails = new AddressDetails("Dreamland","Patagonya" ) }
};
_context.Users.Add(user);
_context.SaveChanges();
//_context.Users.Remove(user);
//_context.SaveChanges();

int minLen = 3;
var result1 =_context.Users.FromSqlRaw($"EXEC getUsers @minLen={minLen}").ToList();
var result2 = _context.Users.FromSqlInterpolated($"EXEC getUsers @minLen={minLen}").ToList();
var result3 = _context.Users.FromSql($"SELECT * FROM Users where Len(Name) > 1").ToList();


// create proc getUsers
//@minLen INT
//AS
//Select * from Users Where LEN(Name) > @minLen;

Console.ReadLine();


#region Eski örnekler
////IConfiguration configuration = new ConfigurationBuilder()
////	.SetBasePath(Environment.CurrentDirectory)
////	.AddJsonFile("appsettins.json", optional: true, reloadOnChange: true)
////	.Build();

////  var ops = new DbContextOptionsBuilder<MgDbContext>()
////  .UseSqlServer(configuration.GetConnectionString("EfcoreConStr"))
////	.LogTo(Console.WriteLine, LogLevel.Information)
////	.Options;

////// MgDbContext db = new (ops);
////// db.Database.EnsureDeleted();
////// db.Database.EnsureCreated();

//var services = new ServiceCollection();
////services.AddDbContext<MgDbContext>(options => {
////	new MgDbContext(ops);
////});

//services.AddDbContext<MgDbContext>(options =>
//{
//	IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
//	options.UseSqlServer(configuration.GetConnectionString("EfcoreConStr"));
//	options.LogTo(Console.WriteLine, LogLevel.Information);
//});

//services.AddSingleton<IConfiguration>(cfg =>
//{
//	return new ConfigurationBuilder()
//	.SetBasePath(Environment.CurrentDirectory)
//	.AddJsonFile("appsettins.json", optional: true, reloadOnChange: true)
//	.Build();
//});
//services.AddScoped<UserMgCommands>();
//services.AddScoped<UserMgQueries>();

//ServiceProvider provider = services.BuildServiceProvider();

//MgDbContext db = provider.GetRequiredService<MgDbContext>();
//db.Database.EnsureDeleted();
//db.Database.Migrate();

//UserMgCommands userCommand = provider.GetRequiredService<UserMgCommands>();
//userCommand.AddUser(new UserMg { Name = "User eleven", Age = 11 });

//UserMgQueries userMgQueries = provider.GetRequiredService<UserMgQueries>();
//var usersAll = userMgQueries.GetAllUsers();

//usersAll.ForEach(user => {
//    Console.WriteLine(user.Id + "\t" + user.Name +"\t"+ user.Age);
//}); 
#endregion




